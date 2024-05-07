import React, {useState, useEffect} from 'react'
import '../../styles/brend/brend.css'
import toast, { Toaster } from 'react-hot-toast';
import { useLocation } from 'react-router-dom';
import { useGetWatchCharacteristicsQuery, useUpdateWatchMutation } from '../../../apis/admin/watchApi';
import { transformString } from '../../../utilities/TransformString';

function Watch() {

  const { data, isLoading } = useGetWatchCharacteristicsQuery();

  const location = useLocation();
  const { watch } = location.state || {};

  const [watchUpdate, setWatchUpdate] = useState(watch);
  const [watchDetail, setWatchDetail] = useState(watch);
  const [additionalCharacteristics, setAdditionalCharacteristics] = useState([]);
  const [characteristics, setCharacteristics] = useState([]);
  const [updateWatchMutation] = useUpdateWatchMutation();

  useEffect(() => {
    if (!isLoading && data) {
        setAdditionalCharacteristics(data.result.additionalCharacteristics);
        setCharacteristics(data.result);
    }
  }, [data, isLoading]);

  if(characteristics.length == 0){
    return <div>Loading...</div>
  }

  const handleUpdateWatch = async (e) => {
    e.preventDefault();

    const formData = new FormData();

    formData.append('nameModel', watchUpdate.nameModel);
    formData.append('gender', watchUpdate.gender);
    formData.append('guarantee', watchUpdate.guarantee);
    formData.append('price', watchUpdate.price);
    formData.append('description', watchUpdate.description);
    formData.append('timeFormat', watchUpdate.timeFormat);
    formData.append('brendId', watchUpdate.brend.id);
    formData.append('isDiscounted', watchUpdate.isDiscounted);
    formData.append('state', watchUpdate.state);
    formData.append('DiscountPrice', watchUpdate.discountPrice);
    formData.append('styleId', watchUpdate.style.id);
    formData.append('countryId', watchUpdate.country.id);
    formData.append('mechanismTypeId', watchUpdate.mechanismType.id);
    formData.append('glassTypeId', watchUpdate.glassType.id);

    formData.append('strap.name', watchUpdate.strap.name);
    formData.append('strap.strapMaterialId', watchUpdate.strap.strapMaterial.id);

    formData.append('clockFace.indicationTypeId', watchUpdate.clockFace.indicationType.id);
    formData.append('clockFace.indicationKindId', watchUpdate.clockFace.indicationKind.id);
    formData.append('clockFace.clockFaceColorId', watchUpdate.clockFace.clockFaceColor.id);

    formData.append('frame.caseShape', watchUpdate.frame.caseShape);
    formData.append('frame.waterResistance', watchUpdate.frame.waterResistance);
    formData.append('frame.frameMaterialId', watchUpdate.frame.frameMaterial.id);
    formData.append('frame.frameColorId', watchUpdate.frame.frameColor.id);
    formData.append('frame.dimensions.length', watchUpdate.frame.dimensions.length);
    formData.append('frame.dimensions.thickness', watchUpdate.frame.dimensions.thickness);
    formData.append('frame.dimensions.width', watchUpdate.frame.dimensions.width);
    formData.append('frame.dimensions.weight', watchUpdate.frame.dimensions.weight);
    formData.append('frame.dimensions.caseDiameter', watchUpdate.frame.dimensions.caseDiameter);

    formData.forEach((value, key) => {
      console.log(`${key}: ${value}`);
    });

    // try {
    //   const response = await updateWatchMutation(formData)

    //   console.log(response)

    //   if(response.error)
    //     toast.error('Watch is not add');
    //   else
    //     toast.success('Watch is add');
    
    //   setNewWatch(watch)      
    //   setImages([])
    //   setWatchAdditionalCharacteristics([])

    //   console.log('Response from server:', response);
    // } catch (error) {
    //   toast.error("Error after save");
    //   console.error('Error while creating watch:', error);
    // }
}


  return (
      <div className='brendAdmin'> 
      <div className="brendTitleContainerEdit">
          <h1 className="brendTitle">Edit Watches</h1>
        </div>
        <div className="brendContainer">
          <div className="brendShow">
            <span className="brendUpdateTitle">Details</span>

            <div className="brendShowBottom">
              <span className="brendShowTitle">Name Model</span>
              <div className="brendShowInfo">
                <span className="brendShowInfoTitle">{watchDetail.nameModel}</span>
              </div>
            </div>

            {watchDetail.description &&  <div className="brendShowBottom">
              <span className="brendShowTitle">Description</span>
                <div className="brendShowInfo">
                  <span className="brendShowInfoTitle">{watchDetail.description}</span>
                </div>
            </div>}

            <div className="brendShowBottom">
              <span className="brendShowTitle">Gender</span>
              <div className="brendShowInfo">
                <span className="brendShowInfoTitle">{watchDetail.gender}</span>
              </div>
            </div>

            <div className="brendShowBottom">
              <span className="brendShowTitle">Price</span>
              <div className="brendShowInfo">
                <span className="brendShowInfoTitle">{watchDetail.price}</span>
              </div>
            </div>

            <div className="brendShowBottom">
              <span className="brendShowTitle">Guarantee</span>
              <div className="brendShowInfo">
                <span className="brendShowInfoTitle">{transformString(watchDetail.guarantee)}</span>
              </div>
            </div>

            {watchDetail.isDiscounted == true &&  <div className="brendShowBottom">
              <span className="brendShowTitle">Discount Price</span>
              <div className="brendShowInfo">
                <span className="brendShowInfoTitle">{watchDetail.discountPrice}</span>
              </div>
            </div>}

            <div className="brendShowBottom">
              <span className="brendShowTitle">Time Format</span>
              <div className="brendShowInfo">
                <span className="brendShowInfoTitle">{transformString(watchDetail.timeFormat)}</span>
              </div>
            </div>

            <div className="brendShowBottom">
              <span className="brendShowTitle">Brend</span>
              <div className="brendShowInfo">
                <span className="brendShowInfoTitle">{watchDetail.brend.name}</span>
              </div>
            </div>

            <div className="brendShowBottom">
              <span className="brendShowTitle">Mechanism Type</span>
              <div className="brendShowInfo">
                <span className="brendShowInfoTitle">{transformString(watchDetail.mechanismType.name)}</span>
              </div>
            </div>

            <div className="brendShowBottom">
              <span className="brendShowTitle">Style</span>
              <div className="brendShowInfo">
                <span className="brendShowInfoTitle">{watchDetail.style.name}</span>
              </div>
            </div>

            <div className="brendShowBottom">
              <span className="brendShowTitle">Strap</span>
              <div className="brendShowInfo">
                <span className="brendShowInfoTitle">{watchDetail.strap.name}</span>
              </div>
            </div>

            <div className="brendShowBottom">
              <span className="brendShowTitle">Strap material</span>
              <div className="brendShowInfo">
                <span className="brendShowInfoTitle">{transformString(watchDetail.strap.strapMaterial.name)}</span>
              </div>
            </div>

            <div className="brendShowBottom">
              <span className="brendShowTitle">Glass Type</span>
              <div className="brendShowInfo">
                <span className="brendShowInfoTitle">{transformString(watchDetail.glassType.name)}</span>
              </div>
            </div>

            <div className="brendShowBottom">
              <span className="brendShowTitle">Clock face color</span>
              <div className="brendShowInfo">
                <span className="brendShowInfoTitle">{transformString(watchDetail.clockFace.clockFaceColor.name)}</span>
              </div>
            </div>

            <div className="brendShowBottom">
              <span className="brendShowTitle">Clock face indication kind</span>
              <div className="brendShowInfo">
                <span className="brendShowInfoTitle">{transformString(watchDetail.clockFace.indicationKind.name)}</span>
              </div>
            </div>

            <div className="brendShowBottom">
              <span className="brendShowTitle">Clock face indication type</span>
              <div className="brendShowInfo">
                <span className="brendShowInfoTitle">{transformString(watchDetail.clockFace.indicationType.name)}</span>
              </div>
            </div>

            <div className="brendShowBottom">
              <span className="brendShowTitle">Country</span>
              <div className="brendShowInfo">
                <span className="brendShowInfoTitle">{transformString(watchDetail.country.name)}</span>
              </div>
            </div>

            <div className="brendShowBottom">
              <span className="brendShowTitle">State</span>
              <div className="brendShowInfo">
                <span className="brendShowInfoTitle">{transformString(watchDetail.state)}</span>
              </div>
            </div>

            <div className="brendShowBottom">
              <span className="brendShowTitle">Frame case shape</span>
              <div className="brendShowInfo">
                <span className="brendShowInfoTitle">{transformString(watchDetail.frame.caseShape)}</span>
              </div>
            </div>

            <div className="brendShowBottom">
              <span className="brendShowTitle">Frame diameter</span>
              <div className="brendShowInfo">
                <span className="brendShowInfoTitle">{transformString(watchDetail.frame.dimensions.caseDiameter)}</span>
              </div>
            </div>

            <div className="brendShowBottom">
              <span className="brendShowTitle">Frame length</span>
              <div className="brendShowInfo">
                <span className="brendShowInfoTitle">{watchDetail.frame.dimensions.length}</span>
              </div>
            </div>

            <div className="brendShowBottom">
              <span className="brendShowTitle">Frame thickness</span>
              <div className="brendShowInfo">
                <span className="brendShowInfoTitle">{watchDetail.frame.dimensions.thickness}</span>
              </div>
            </div>

            <div className="brendShowBottom">
              <span className="brendShowTitle">Frame weight</span>
              <div className="brendShowInfo">
                <span className="brendShowInfoTitle">{watchDetail.frame.dimensions.weight}</span>
              </div>
            </div>

            <div className="brendShowBottom">
              <span className="brendShowTitle">Frame width</span>
              <div className="brendShowInfo">
                <span className="brendShowInfoTitle">{watchDetail.frame.dimensions.width}</span>
              </div>
            </div>

            <div className="brendShowBottom">
              <span className="brendShowTitle">Frame color</span>
              <div className="brendShowInfo">
                <span className="brendShowInfoTitle">{transformString(watchDetail.frame.frameColor.name)}</span>
              </div>
            </div>

            <div className="brendShowBottom">
              <span className="brendShowTitle">Frame material</span>
              <div className="brendShowInfo">
                <span className="brendShowInfoTitle">{transformString(watchDetail.frame.frameMaterial.name)}</span>
              </div>
            </div>

            <div className="brendShowBottom">
              <span className="brendShowTitle">Frame water resistance</span>
              <div className="brendShowInfo">
                <span className="brendShowInfoTitle">{transformString(watchDetail.frame.waterResistance)}</span>
              </div>
            </div>

            <div className="brendShowBottom">
              <span className="brendShowTitle">Additional characteristics</span>
              <div className="brendShowInfo">
                <ul>
                    {watchDetail.watchAdditionalCharacteristics.map((additionalCharacteristic) => {
                        const characteristic = additionalCharacteristics.find(characteristic => characteristic.id === additionalCharacteristic.additionalCharacteristicsId);
                        
                        if (characteristic) {
                            return (
                                <li key={characteristic.id}>
                                    {characteristic.name}
                                </li>
                            );
                        } else {
                            return null;
                        }
                    })}
                </ul>
              </div>
            </div>

          </div>
            <div className="brendUpdate">
              <span className="brendUpdateTitle">Edit</span>
              <form className="brendUpdateForm" onSubmit={handleUpdateWatch}>
                <div className="brendUpdateLeft">

                  <div className="brendUpdateItem">
                    <label>Name Model</label>
                    <input
                      type="text"
                      placeholder={watchUpdate.nameModel}
                      className="brendUpdateInput"
                      value={watchUpdate.nameModel}
                      onChange={(e) => setWatchUpdate((prev) => ({...prev,nameModel: e.target.value}))}
                    />
                  </div>

                  <div className="brendUpdateItem">
                    <label>Description</label>
                    <textarea
                      type="text"
                      placeholder={watchUpdate.description}
                      className="brendUpdateTextArea"
                      value={watchUpdate.description}
                      onChange={(e) => setWatchUpdate((prev) => ({...prev,description: e.target.value}))}
                    />
                  </div>

                  <div className="brendUpdateItem">
                    <label>Price</label>
                    <input
                      type="number"
                      placeholder={watchUpdate.price}
                      className="brendUpdateInput"
                      value={watchUpdate.price}
                      onChange={(e) => setWatchUpdate((prev) => ({...prev,price: e.target.value}))}
                    />
                  </div>

                  <div className="brendUpdateItem">
                    <label>State</label>
                    <select id="stateWatch" name="state" value={watchUpdate.state} onChange={(e) => setWatchUpdate((prev) => ({...prev,state: e.target.value}))}>
                      {characteristics.watchStateEnums.map((index, state) => (
                        <option key={state} value={index}>{transformString(index)}</option>
                      ))}
                    </select>
                  </div>

                  <div className="brendUpdateItem">
                    <label>is Discount</label>
                    <input type="checkbox" 
                    checked={watchUpdate.isDiscounted} 
                    onChange={(e) => setWatchUpdate((prev) => ({...prev,isDiscounted: e.target.checked}))}/>
                  </div>

                  <div className="brendUpdateItem">
                    <label>Discount Price</label>
                    <input
                      type="number"
                      placeholder={watchUpdate.discountPrice}
                      className="brendUpdateInput"
                      value={watchUpdate.discountPrice}
                      onChange={(e) => setWatchUpdate((prev) => ({...prev,discountPrice: e.target.value}))}
                    />
                  </div>

                  <div className="brendUpdateItem">
                    <label>Gender</label>
                    <select id="gender" name="gender" value={watchUpdate.gender} onChange={(e) => setWatchUpdate((prev) => ({...prev,gender: e.target.value}))}>
                      {characteristics.genderEnums.map((index, gender) => (
                        <option key={gender} value={index}>{index}</option>
                      ))}
                    </select>
                  </div>

                  <div className="brendUpdateItem">
                    <label>Guarantee</label>
                    <select id="guaranteeMonth" name="guarantees" value={watchUpdate.guarantee}  onChange={(e) => setWatchUpdate((prev) => ({...prev,guarantee: e.target.value}))}>
                      {characteristics.guaranteeMonth.map((index, guarantee) => (
                        <option key={guarantee} value={index}>{transformString(index)}</option>
                      ))}
                    </select>
                  </div>

                  <div className="brendUpdateItem">
                    <label>Time Format</label>
                    <select id="timeFormats" name="timeFormats" value={watchUpdate.timeFormat}  onChange={(e) => setWatchUpdate((prev) => ({...prev,timeFormat: e.target.value}))}>
                      {characteristics.timeFormatEnums.map((index, timeFormat) => (
                        <option key={timeFormat} value={index}>{transformString(index)}</option>
                      ))}
                    </select>
                  </div>

                  <div className="brendUpdateItem">
                    <label>Brend</label>
                    <select id="brends" name="brends" value={watchUpdate.brend.id}  onChange={(e) => setWatchUpdate((prev) => ({...prev,brendId: parseInt(e.target.value)}))}>
                      {characteristics.brends.map((brend) => (
                        <option key={brend.id} value={brend.id}>{brend.name}</option>
                      ))}
                    </select>
                  </div>

                  <div className="brendUpdateItem">
                    <label>Style</label>
                    <select id="styles" name="styles" value={watchUpdate.style.id}  onChange={(e) => setWatchUpdate((prev) => ({...prev,styleId: parseInt(e.target.value)}))}>
                      {characteristics.styles.map((style) => (
                        <option key={style.id} value={style.id}>{style.name}</option>
                      ))}
                    </select>
                  </div>

                  <div className="brendUpdateItem">
                    <label>Strap Name</label>
                    <select id="straps" name="straps" value={watchUpdate.strap.name}  onChange={(e) => setWatchUpdate((prev) => ({...prev,strap: {...prev.strap, name: e.target.value}}))}>
                      {characteristics.strapEnums.map((index, strap) => (
                        <option key={strap} value={index}>{index}</option>
                      ))}
                    </select>
                  </div>

                  <div className="brendUpdateItem">
                    <label>Strap Material</label>
                    <select id="strapMaterials" name="strapMaterials" value={watchUpdate.strap.strapMaterial.id}  onChange={(e) => setWatchUpdate((prev) => ({...prev,strap: {...prev.strap, strapMaterialId : parseInt(e.target.value)}}))}>
                      {characteristics.strapMaterials.map((strapMaterial) => (
                        <option key={strapMaterial.id} value={strapMaterial.id}>{transformString(strapMaterial.name)}</option>
                      ))}
                    </select>
                  </div>

                  <div className="brendUpdateItem">
                    <label>Country</label>
                    <select id="countries" name="countries" value={watchUpdate.country.id}  onChange={(e) => setWatchUpdate((prev) => ({...prev,countryId: e.target.value}))}>
                      {characteristics.countries.map((country) => (
                        <option key={country.id} value={country.id}>{country.name}</option>
                      ))}
                    </select>
                  </div>

                  <div className="brendUpdateItem">
                    <label>Mechanism Type</label>
                    <select id="mechanismTypes" name="mechanismTypes" value={watchUpdate.mechanismType.id}  onChange={(e) => setWatchUpdate((prev) => ({...prev,mechanismTypeId: parseInt(e.target.value)}))}>
                      {characteristics.mechanismTypes.map((mechanismType) => (
                        <option key={mechanismType.id} value={mechanismType.id}>{transformString(mechanismType.name)}</option>
                      ))}
                    </select>
                  </div>

                  <div className="brendUpdateItem">
                    <label>ClockFace Indication Kind</label>
                    <select id="indicationKinds" name="indicationKinds" value={watchUpdate.clockFace.indicationKind.id}  onChange={(e) => setWatchUpdate((prev) => ({...prev,clockFace: {...prev.clockFace, indicationKindId : parseInt(e.target.value)}}))}>
                      {characteristics.indicationKinds.map((indicationKind) => (
                        <option key={indicationKind.id} value={indicationKind.id}>{transformString(indicationKind.name)}</option>
                      ))}
                    </select>
                  </div>

                  <div className="brendUpdateItem">
                    <label>ClockFace Indication Type</label>
                    <select id="indicationTypes" name="indicationKinds" value={watchUpdate.clockFace.indicationType.id}  onChange={(e) => setWatchUpdate((prev) => ({...prev,clockFace: {...prev.clockFace, indicationTypeId : parseInt(e.target.value)}}))}>
                      {characteristics.indicationTypes.map((indicationType) => (
                        <option key={indicationType.id} value={indicationType.id}>{transformString(indicationType.name)}</option>
                      ))}
                    </select>
                  </div>

                  <div className="brendUpdateItem">
                    <label>Glass type</label>
                    <select id="glassTypes" name="glassTypes" value={watchUpdate.glassType.id}  onChange={(e) => setWatchUpdate((prev) => ({...prev,glassTypeId: parseInt(e.target.value)}))}>
                      {characteristics.glassTypes.map((glassType) => (
                        <option key={glassType.id} value={glassType.id}>{transformString(glassType.name)}</option>
                      ))}
                    </select>
                  </div>

                  <div className="brendUpdateItem">
                    <label>ClockFace Color</label>
                    <select id="clockFaceColors" name="indicationKinds" value={watchUpdate.clockFace.clockFaceColor.id}  onChange={(e) => setWatchUpdate((prev) => ({...prev,clockFace: {...prev.clockFace, clockFaceColorId : parseInt(e.target.value)}}))}>
                      {characteristics.clockFaceColors.map((clockFaceColor) => (
                        <option key={clockFaceColor.id} value={clockFaceColor.id}>{transformString(clockFaceColor.name)}</option>
                      ))}
                    </select>
                  </div>

                  <div className="brendUpdateItem">
                    <label>Frame Color</label>
                    <select id="frameColors" name="frameColors" value={watchUpdate.frame.frameColor.id}  onChange={(e) => setWatchUpdate((prev) => ({...prev,frame: {...prev.frame, frameColorId : parseInt(e.target.value)}}))}>
                      {characteristics.frameColors.map((frameColor) => (
                        <option key={frameColor.id} value={frameColor.id}>{transformString(frameColor.name)}</option>
                      ))}
                    </select>
                  </div>

                  <div className="brendUpdateItem">
                    <label>Water Resistance</label>
                    <select id="waterResistances" name="waterResistances" value={watchUpdate.frame.waterResistance}  onChange={(e) => setWatchUpdate((prev) => ({...prev,frame: {...prev.frame, waterResistance : e.target.value}}))}>
                      {characteristics.waterResistanceEnums.map((index, waterResistance) => (
                        <option key={waterResistance} value={index}>{transformString(index)}</option>
                      ))}
                    </select>
                  </div>

                  <div className="brendUpdateItem">
                    <label>Frame material</label>
                    <select id="frameMaterials" name="frameMaterials" value={watchUpdate.frame.frameMaterial.id}  onChange={(e) => setWatchUpdate((prev) => ({...prev,frame: {...prev.frame, frameMaterialId : parseInt(e.target.value)}}))}>
                      {characteristics.frameMaterials.map((frameMaterial) => (
                        <option key={frameMaterial.id} value={frameMaterial.id}>{transformString(frameMaterial.name)}</option>
                      ))}
                    </select>
                  </div>

                  
                  <div className="brendUpdateItem">
                    <label htmlFor='length'>Length</label>
                    <input id='length' type="number" className='inputWatchStyle' value={watchUpdate.frame.dimensions.length} onChange={(e) => setWatchUpdate((prev) => ({...prev,frame: {...prev.frame, dimensions : {...prev.frame.dimensions, length : e.target.value}}}))}/>
                  </div>

                  <div className="brendUpdateItem">
                    <label htmlFor='thickness'>Thickness</label>
                    <input id='thickness' type="numer" className='inputWatchStyle' value={watchUpdate.frame.dimensions.thickness} onChange={(e) => setWatchUpdate((prev) => ({...prev,frame: {...prev.frame, dimensions : {...prev.frame.dimensions, thickness : e.target.value}}}))}/>
                  </div>

                  <div className="brendUpdateItem">
                    <label htmlFor='width'>Width</label>
                    <input id='width' type="number" className='inputWatchStyle' value={watchUpdate.frame.dimensions.width} onChange={(e) => setWatchUpdate((prev) => ({...prev,frame: {...prev.frame, dimensions : {...prev.frame.dimensions, width : e.target.value}}}))}/>
                  </div>

                  <div className="brendUpdateItem">
                    <label htmlFor='Weight'>Weight</label>
                    <input id='Weight' type="number" className='inputWatchStyle' value={watchUpdate.frame.dimensions.weight} onChange={(e) => setWatchUpdate((prev) => ({...prev,frame: {...prev.frame, dimensions : {...prev.frame.dimensions, weight : e.target.value}}}))}/>
                  </div>

                  <div className="brendUpdateItem">
                    <label>Frame material</label>
                    <select id="Diameter" name="Diameter" value={watchUpdate.frame.dimensions.caseDiameter}  onChange={(e) => setWatchUpdate((prev) => ({...prev,frame: {...prev.frame, dimensions : {...prev.frame.dimensions, caseDiameter : e.target.value}}}))}>
                      {characteristics.caseDiameterEnums.map((index, caseDiameter) => (
                        <option key={caseDiameter} value={index}>{transformString(index)}</option>
                      ))}
                    </select>
                  </div>
                  
                  <button className="brendUpdateButton">Update</button>


                </div>
              </form>
              <Toaster position="bottom-right" reverseOrder={false} />
            </div>
        </div>
  
      </div>
  )
}

export default Watch