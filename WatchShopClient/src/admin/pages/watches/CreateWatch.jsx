import React, { useEffect, useState } from 'react'
import '../../styles/watch/createWatch.css'
import { useNavigate } from 'react-router-dom';
import toast, { Toaster } from 'react-hot-toast';
import { useAddNewImagesMutation, useAddNewWatchMutation, useGetWatchCharacteristicsQuery } from '../../../apis/admin/watchApi';
import axios from 'axios';

const watch = {
   nameModel : "",
   gender: "",
   guarantee: "",
   price: 0,
   description: "",
   timeFormat : "",
   brendId : 1,
   styleId : 1,
   strap : {
     name : "",
     strapMaterialId : 1
   },
   countryId : 1,
   mechanismTypeId : 1,
   glassTypeId : 1,
   clockFace : {
    indicationTypeId: 1,
    indicationKindId: 1,
    clockFaceColorId: 1
   },
   frame : {
    caseShape: "",
    waterResistance: "",
    frameMaterialId: 1,
    frameColorId : 1,
    dimensions : {
      length : 0,
      thickness: 0,
      width: 0,
      weight: 0,
      caseDiameter : ""
    }
   },
   watchAdditionalCharacteristics : []
}

function CreateWatch() {

  const navigate = useNavigate();
  const [newWatch, setNewWatch] = useState(watch)
  const { data, isLoading} = useGetWatchCharacteristicsQuery(null);
  const [images, setImages] = useState([])

  const [addNewWatchMutation] = useAddNewWatchMutation();
  const [addNewImagesMutation] = useAddNewImagesMutation();
  
  useEffect(() => {
    if (!isLoading && data) {
      setNewWatch(mapApiDataToWatchModel(data.result));
    }
  }, [isLoading, data]);

  if (isLoading) {
    return <div>Loading...</div>;
  }


  function mapApiDataToWatchModel(apiData) {
    return {
      nameModel: "",
      gender: apiData.genderEnums[0] || "",
      guarantee: apiData.guaranteeMonth[0] || "",
      price: 0,
      description: "",
      timeFormat: apiData.timeFormatEnums[0] || "",
      brendId: apiData.brends[0].id || 1,
      styleId: apiData.styles[0].id || 1,
      strap: {
        name: apiData.strapEnums[0] || "",
        strapMaterialId: apiData.strapMaterials[0].id || 1
      },
      countryId: apiData.countries[0].id || 1,
      mechanismTypeId: apiData.mechanismTypes[0].id || 1,
      glassTypeId: apiData.glassTypes[0].id || 1,
      clockFace: {
        indicationTypeId: apiData.indicationTypes[0].id || 1,
        indicationKindId: apiData.indicationKinds[0].id || 1,
        clockFaceColorId: apiData.clockFaceColors[0].id || 1
      },
      frame: {
        caseShape: apiData.caseShapeEnums[0] || "",
        waterResistance: apiData.waterResistanceEnums[0] || "",
        frameMaterialId: apiData.frameMaterials[0].id || 1,
        frameColorId: apiData.frameColors[0].id || 1,
        dimensions: {
          length:  0,
          thickness:  0,
          width:  0,
          weight:  0,
          caseDiameter: apiData.caseDiameterEnums[0] || ""
        }
      },
      watchAdditionalCharacteristics: []
    };
  }

  const handleSubmit = async (e) => {
      e.preventDefault();

      console.log(newWatch)

      
      const formData = new FormData();

      formData.append('nameModel', newWatch.nameModel);
      formData.append('gender', newWatch.gender);
      formData.append('guarantee', newWatch.guarantee);
      formData.append('price', newWatch.price);
      formData.append('description', newWatch.description);
      formData.append('timeFormat', newWatch.timeFormat);
      formData.append('brendId', newWatch.brendId);
      formData.append('styleId', newWatch.styleId);
      formData.append('countryId', newWatch.countryId);
      formData.append('mechanismTypeId', newWatch.mechanismTypeId);
      formData.append('glassTypeId', newWatch.glassTypeId);

      formData.append('strap.name', newWatch.strap.name);
      formData.append('strap.strapMaterialId', newWatch.strap.strapMaterialId);

      formData.append('clockFace.indicationTypeId', newWatch.clockFace.indicationTypeId);
      formData.append('clockFace.indicationKindId', newWatch.clockFace.indicationKindId);
      formData.append('clockFace.clockFaceColorId', newWatch.clockFace.clockFaceColorId);

      formData.append('frame.caseShape', newWatch.frame.caseShape);
      formData.append('frame.waterResistance', newWatch.frame.waterResistance);
      formData.append('frame.frameMaterialId', newWatch.frame.frameMaterialId);
      formData.append('frame.frameColorId', newWatch.frame.frameColorId);
      formData.append('frame.dimensions.length', newWatch.frame.dimensions.length);
      formData.append('frame.dimensions.thickness', newWatch.frame.dimensions.thickness);
      formData.append('frame.dimensions.width', newWatch.frame.dimensions.width);
      formData.append('frame.dimensions.weight', newWatch.frame.dimensions.weight);
      formData.append('frame.dimensions.caseDiameter', newWatch.frame.dimensions.caseDiameter);

      for (let i = 0; i < images.length; i++) {
        formData.append('photos', images[i]);
      }

      try {
        const response = addNewWatchMutation(formData)

        console.log(response)
  
        console.log('Response from server:', response);
      } catch (error) {
        console.error('Error while creating watch:', error);
      }


      //const resultOperation = await addNewWatchMutation(newWatch);

      //console.log(resultOperation)

        // if(resultOperation.data.isSuccess)
        //     toast.success('Watch is add');
        // else
        //     toast.error('Watch is not add');
      
      //setNewWatch(watch)      
  }

  const handleFileChange = (e) => {
    setImages([...images, ...e.target.files]);
  };

  const handleCharacteristicChange = (event) => {
    const characteristicId = parseInt(event.target.value);
    if (event.target.checked) {
      setNewWatch((prev) => ({
        ...prev,
        watchAdditionalCharacteristics: [...prev.watchAdditionalCharacteristics, characteristicId]
      }));
    } else {
      setNewWatch((prev) => ({
        ...prev,
        watchAdditionalCharacteristics: prev.watchAdditionalCharacteristics.filter(id => id !== characteristicId)
      }));
    }
};



  return (
    <div className='creatWatch'>
      <div className="newWatch">
            <h1 className="addWatchTitle">New Watch</h1>
            <form className="addWatchForm" onSubmit={handleSubmit}>

                <div className="addWatchItem">
                    <label htmlFor='nameModel'>Name Model</label>
                    <input id='nameModel' type="text" className='inputWatchStyle' value={newWatch.nameModel} onChange={(e) => setNewWatch((prev) => ({...prev,nameModel: e.target.value}))}/>
                </div>

                <div className="addWatchItem">
                  <label htmlFor='price'>Price</label>
                    <input id='price' type="number" className='inputWatchStyle' value={newWatch.price} onChange={(e) => setNewWatch((prev) => ({...prev,price: e.target.value}))}/>
                </div>

                <div className="addBrendItem">
                    <label htmlFor='description'>Description</label>
                    <textarea  id='description' type="text" placeholder="Was created ....." className='textAreaBrendStyle' value={newWatch.description} onChange={(e) => setNewWatch((prev) => ({...prev,description: e.target.value}))}  />
                </div>

                <div className="addWatchItem">
                  <label htmlFor="gender">Gender:</label>
                  <select id="gender" name="gender" value={newWatch.gender} onChange={(e) => setNewWatch((prev) => ({...prev,gender: e.target.value}))}>
                    {data.result.genderEnums.map((index, gender) => (
                      <option key={gender} value={index}>{index}</option>
                    ))}
                  </select>
                </div>

                <div className="addWatchItem">
                  <label htmlFor="guaranteeMonth">Guarantee:</label>
                  <select id="guaranteeMonth" name="guarantees" value={newWatch.guarantee}  onChange={(e) => setNewWatch((prev) => ({...prev,guarantee: e.target.value}))}>
                    {data.result.guaranteeMonth.map((index, guarantee) => (
                      <option key={guarantee} value={index}>{index}</option>
                    ))}
                  </select>
                </div>

                <div className="addWatchItem">
                  <label htmlFor="timeFormats">TimeFormat:</label>
                  <select id="timeFormats" name="timeFormats" value={newWatch.timeFormat}  onChange={(e) => setNewWatch((prev) => ({...prev,timeFormat: e.target.value}))}>
                    {data.result.timeFormatEnums.map((index, timeFormat) => (
                      <option key={timeFormat} value={index}>{index}</option>
                    ))}
                  </select>
                </div>

                <div className="addWatchItem">
                  <label htmlFor="brends">Brends:</label>
                  <select id="brends" name="brends"  onChange={(e) => setNewWatch((prev) => ({...prev,brendId: parseInt(e.target.value)}))}>
                    {data.result.brends.map((brend) => (
                      <option key={brend.id} value={brend.id}>{brend.name}</option>
                    ))}
                  </select>
                </div>

                <div className="addWatchItem">
                  <label htmlFor="styles">Styles:</label>
                  <select id="styles" name="styles" value={newWatch.styleId}  onChange={(e) => setNewWatch((prev) => ({...prev,styleId: parseInt(e.target.value)}))}>
                    {data.result.styles.map((style) => (
                      <option key={style.id} value={style.id}>{style.name}</option>
                    ))}
                  </select>
                </div>

                <div className="addWatchItem">
                  <label htmlFor="straps">Strap Name:</label>
                  <select id="straps" name="straps" value={newWatch.strap.name}  onChange={(e) => setNewWatch((prev) => ({...prev,strap: {...prev.strap, name: e.target.value}}))}>
                    {data.result.strapEnums.map((index, strap) => (
                      <option key={strap} value={index}>{index}</option>
                    ))}
                  </select>
                </div>

                <div className="addWatchItem">
                  <label htmlFor="strapMaterials">Strap Material:</label>
                  <select id="strapMaterials" name="strapMaterials" value={newWatch.strap.strapMaterialId}  onChange={(e) => setNewWatch((prev) => ({...prev,strap: {...prev.strap, strapMaterialId : parseInt(e.target.value)}}))}>
                    {data.result.strapMaterials.map((strapMaterial) => (
                      <option key={strapMaterial.id} value={strapMaterial.id}>{strapMaterial.name}</option>
                    ))}
                  </select>
                </div>

                <div className="addWatchItem">
                  <label htmlFor="countries">Country:</label>
                  <select id="countries" name="countries" value={newWatch.countryId}  onChange={(e) => setNewWatch((prev) => ({...prev,countryId: e.target.value}))}>
                    {data.result.countries.map((country) => (
                      <option key={country.id} value={country.id}>{country.name}</option>
                    ))}
                  </select>
                </div>

                <div className="addWatchItem">
                  <label htmlFor="mechanismTypes">Mechanism Type:</label>
                  <select id="mechanismTypes" name="mechanismTypes" value={newWatch.mechanismTypeId}  onChange={(e) => setNewWatch((prev) => ({...prev,mechanismTypeId: parseInt(e.target.value)}))}>
                    {data.result.mechanismTypes.map((mechanismType) => (
                      <option key={mechanismType.id} value={mechanismType.id}>{mechanismType.name}</option>
                    ))}
                  </select>
                </div>

                <div className="addWatchItem">
                  <label htmlFor="glassTypes">Glass Type:</label>
                  <select id="glassTypes" name="glassTypes" value={newWatch.glassTypeId}  onChange={(e) => setNewWatch((prev) => ({...prev,glassTypeId: parseInt(e.target.value)}))}>
                    {data.result.glassTypes.map((glassType) => (
                      <option key={glassType.id} value={glassType.id}>{glassType.name}</option>
                    ))}
                  </select>
                </div>

                <div className="addWatchItem">
                  <label htmlFor="indicationKinds">ClockFace Indication Kind:</label>
                  <select id="indicationKinds" name="indicationKinds" value={newWatch.clockFace.indicationKindId}  onChange={(e) => setNewWatch((prev) => ({...prev,clockFace: {...prev.clockFace, indicationKindId : parseInt(e.target.value)}}))}>
                    {data.result.indicationKinds.map((indicationKind) => (
                      <option key={indicationKind.id} value={indicationKind.id}>{indicationKind.name}</option>
                    ))}
                  </select>
                </div>

                <div className="addWatchItem">
                  <label htmlFor="indicationTypes">ClockFace Indication Type:</label>
                  <select id="indicationTypes" name="indicationKinds" value={newWatch.clockFace.indicationTypeId}  onChange={(e) => setNewWatch((prev) => ({...prev,clockFace: {...prev.clockFace, indicationTypeId : parseInt(e.target.value)}}))}>
                    {data.result.indicationTypes.map((indicationType) => (
                      <option key={indicationType.id} value={indicationType.id}>{indicationType.name}</option>
                    ))}
                  </select>
                </div>

                <div className="addWatchItem">
                  <label htmlFor="clockFaceColors">ClockFace Color:</label>
                  <select id="clockFaceColors" name="indicationKinds" value={newWatch.clockFace.clockFaceColorId}  onChange={(e) => setNewWatch((prev) => ({...prev,clockFace: {...prev.clockFace, clockFaceColorId : parseInt(e.target.value)}}))}>
                    {data.result.clockFaceColors.map((clockFaceColor) => (
                      <option key={clockFaceColor.id} value={clockFaceColor.id}>{clockFaceColor.name}</option>
                    ))}
                  </select>
                </div>

                <div className="addWatchItem">
                  <label htmlFor="caseShapeEnums">Frame Case Shape:</label>
                  <select id="caseShapeEnums" name="caseShapeEnums" value={newWatch.frame.caseShape}  onChange={(e) => setNewWatch((prev) => ({...prev,frame: {...prev.frame, caseShape : e.target.value}}))}>
                    {data.result.caseShapeEnums.map((index, caseShape) => (
                      <option key={caseShape} value={index}>{index}</option>
                    ))}
                  </select>
                </div>

                <div className="addWatchItem">
                  <label htmlFor="waterResistances">Frame Case Shape:</label>
                  <select id="waterResistances" name="waterResistances" value={newWatch.frame.waterResistance}  onChange={(e) => setNewWatch((prev) => ({...prev,frame: {...prev.frame, waterResistance : e.target.value}}))}>
                    {data.result.waterResistanceEnums.map((index, waterResistance) => (
                      <option key={waterResistance} value={index}>{index}</option>
                    ))}
                  </select>
                </div>

                <div className="addWatchItem">
                  <label htmlFor="frameColors">Frame Color:</label>
                  <select id="frameColors" name="frameColors" value={newWatch.frame.frameColorId}  onChange={(e) => setNewWatch((prev) => ({...prev,frame: {...prev.frame, frameColorId : parseInt(e.target.value)}}))}>
                    {data.result.frameColors.map((frameColor) => (
                      <option key={frameColor.id} value={frameColor.id}>{frameColor.name}</option>
                    ))}
                  </select>
                </div>

                <div className="addWatchItem">
                  <label htmlFor="frameMaterials">Frame Material:</label>
                  <select id="frameMaterials" name="frameMaterials" value={newWatch.frame.frameMaterialId}  onChange={(e) => setNewWatch((prev) => ({...prev,frame: {...prev.frame, frameMaterialId : parseInt(e.target.value)}}))}>
                    {data.result.frameMaterials.map((frameMaterial) => (
                      <option key={frameMaterial.id} value={frameMaterial.id}>{frameMaterial.name}</option>
                    ))}
                  </select>
                </div>

                <div className="addWatchItem">
                    <label htmlFor='length'>Length</label>
                    <input id='length' type="number" className='inputWatchStyle' value={newWatch.frame.dimensions.length} onChange={(e) => setNewWatch((prev) => ({...prev,frame: {...prev.frame, dimensions : {...prev.frame.dimensions, length : e.target.value}}}))}/>
                </div>

                <div className="addWatchItem">
                    <label htmlFor='thickness'>Thickness</label>
                    <input id='thickness' type="numer" className='inputWatchStyle' value={newWatch.frame.dimensions.thickness} onChange={(e) => setNewWatch((prev) => ({...prev,frame: {...prev.frame, dimensions : {...prev.frame.dimensions, thickness : e.target.value}}}))}/>
                </div>

                <div className="addWatchItem">
                    <label htmlFor='width'>Width</label>
                    <input id='width' type="number" className='inputWatchStyle' value={newWatch.frame.dimensions.width} onChange={(e) => setNewWatch((prev) => ({...prev,frame: {...prev.frame, dimensions : {...prev.frame.dimensions, width : e.target.value}}}))}/>
                </div>

                <div className="addWatchItem">
                    <label htmlFor='Weight'>Weight</label>
                    <input id='Weight' type="number" className='inputWatchStyle' value={newWatch.frame.dimensions.weight} onChange={(e) => setNewWatch((prev) => ({...prev,frame: {...prev.frame, dimensions : {...prev.frame.dimensions, weight : e.target.value}}}))}/>
                </div>

                <div className="addWatchItem">
                  <label htmlFor="Diameter">Diameter:</label>
                  <select id="Diameter" name="Diameter" value={newWatch.frame.dimensions.caseDiameter}  onChange={(e) => setNewWatch((prev) => ({...prev,frame: {...prev.frame, dimensions : {...prev.frame.dimensions, caseDiameter : e.target.value}}}))}>
                    {data.result.caseDiameterEnums.map((index, caseDiameter) => (
                      <option key={caseDiameter} value={index}>{index}</option>
                    ))}
                  </select>
                </div>

                <div className="characteristics-container">
                  <p>Выберите дополнительные характеристики:</p>
                  {data.result.additionalCharacteristics.map(characteristic => (
                    <div key={characteristic.id} className="characteristics-item">
                      <input
                        type="checkbox"
                        id={`characteristic-${characteristic.id}`}
                        value={characteristic.id}
                        checked={newWatch.watchAdditionalCharacteristics.includes(characteristic.id)}
                        onChange={handleCharacteristicChange}
                      />
                      <label htmlFor={`characteristic-${characteristic.id}`}>{characteristic.name}</label>
                    </div>
                  ))}
                </div>

                <div className="addWatchItem">
                  <div>
                    <label htmlFor="fileInput">Upload Files:</label>
                    <input type="file" id="fileInput" multiple onChange={handleFileChange} />
                  </div>

                  <div>
                    <p>Selected Files:</p>
                    {/* <ul>
                      {images.map((file, index) => (
                        <li key={index} value={index}>{file.name}</li>
                      ))}
                    </ul> */}

                  </div>
                </div>

                <div className='watchContainerButtons'>
                    <button className="addWatchButton">Create</button>
                    <button className="backWatchButton" onClick={() => navigate("/admin/watches")}>Back</button>
                </div>



            </form>
        </div>
        <Toaster position="bottom-right" reverseOrder={false} />
    </div>
  )
}

export default CreateWatch