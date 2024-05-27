import React, {useState, useEffect} from 'react'
import '../../styles/brend/brend.css'
import toast, { Toaster } from 'react-hot-toast';
import { useLocation } from 'react-router-dom';
import { useGetWatchCharacteristicsQuery, useUpdateWatchMutation } from '../../../apis/admin/watchApi';

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
  else{
    console.log(watchUpdate)
  }

  const handleUpdateWatch = async (e) => {
    e.preventDefault();

    console.log(watchUpdate)

    try {
      const response = await updateWatchMutation(watchUpdate)

      console.log(response)

      if(response.error)
        toast.error('Watch is not update');
      else
        toast.success('Watch is updated');
     
    } catch (error) {
      toast.error("Error after save");
      console.error('Error while update watch:', error);
    }
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
                <span className="brendShowInfoTitle">{ (watchDetail.guarantee)}</span>
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
                <span className="brendShowInfoTitle">{ (watchDetail.timeFormat)}</span>
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
                <span className="brendShowInfoTitle">{ (watchDetail.mechanismType.name)}</span>
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
                <span className="brendShowInfoTitle">{ (watchDetail.strap.strapMaterial.name)}</span>
              </div>
            </div>

            <div className="brendShowBottom">
              <span className="brendShowTitle">Glass Type</span>
              <div className="brendShowInfo">
                <span className="brendShowInfoTitle">{ (watchDetail.glassType.name)}</span>
              </div>
            </div>

            <div className="brendShowBottom">
              <span className="brendShowTitle">Clock face color</span>
              <div className="brendShowInfo">
                <span className="brendShowInfoTitle">{ (watchDetail.clockFace.clockFaceColor.name)}</span>
              </div>
            </div>

            <div className="brendShowBottom">
              <span className="brendShowTitle">Clock face indication kind</span>
              <div className="brendShowInfo">
                <span className="brendShowInfoTitle">{ (watchDetail.clockFace.indicationKind.name)}</span>
              </div>
            </div>

            <div className="brendShowBottom">
              <span className="brendShowTitle">Clock face indication type</span>
              <div className="brendShowInfo">
                <span className="brendShowInfoTitle">{ (watchDetail.clockFace.indicationType.name)}</span>
              </div>
            </div>

            <div className="brendShowBottom">
              <span className="brendShowTitle">Country</span>
              <div className="brendShowInfo">
                <span className="brendShowInfoTitle">{ (watchDetail.country.name)}</span>
              </div>
            </div>

            <div className="brendShowBottom">
              <span className="brendShowTitle">State</span>
              <div className="brendShowInfo">
                <span className="brendShowInfoTitle">{watchDetail.state}</span>
              </div>
            </div>

            <div className="brendShowBottom">
              <span className="brendShowTitle">Frame case shape</span>
              <div className="brendShowInfo">
                <span className="brendShowInfoTitle">{ (watchDetail.frame.caseShape)}</span>
              </div>
            </div>

            <div className="brendShowBottom">
              <span className="brendShowTitle">Frame diameter</span>
              <div className="brendShowInfo">
                <span className="brendShowInfoTitle">{ (watchDetail.frame.dimensions.caseDiameter)}</span>
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
                <span className="brendShowInfoTitle">{ (watchDetail.frame.frameColor.name)}</span>
              </div>
            </div>

            <div className="brendShowBottom">
              <span className="brendShowTitle">Frame material</span>
              <div className="brendShowInfo">
                <span className="brendShowInfoTitle">{ (watchDetail.frame.frameMaterial.name)}</span>
              </div>
            </div>

            <div className="brendShowBottom">
              <span className="brendShowTitle">Frame water resistance</span>
              <div className="brendShowInfo">
                <span className="brendShowInfoTitle">{ (watchDetail.frame.waterResistance)}</span>
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
                      onChange={(e) => setWatchUpdate((prev) => ({ ...prev, nameModel: e.target.value }))}
                    />
                  </div>

                  <div className="brendUpdateItem">
                    <label>Description</label>
                    <textarea
                      placeholder={watchUpdate.description}
                      className="brendUpdateTextArea"
                      value={watchUpdate.description}
                      onChange={(e) => setWatchUpdate((prev) => ({ ...prev, description: e.target.value }))}
                    />
                  </div>

                  <div className="brendUpdateItem">
                    <label>Price</label>
                    <input
                      type="number"
                      placeholder={watchUpdate.price}
                      className="brendUpdateInput"
                      value={watchUpdate.price}
                      onChange={(e) => setWatchUpdate((prev) => ({ ...prev, price: e.target.value }))}
                    />
                  </div>

                  <div className="brendUpdateItem">
                    <label>State</label>
                    <select
                      id="stateWatch"
                      name="state"
                      value={watchUpdate.state}
                      onChange={(e) => setWatchUpdate((prev) => ({ ...prev, state: e.target.value }))}
                    >
                      {characteristics.watchStateEnums.map((state, index) => (
                        <option key={index} value={state}>{state}</option>
                      ))}
                    </select>
                  </div>

                  <div className="brendUpdateItem">
                    <label>is Discount</label>
                    <input
                      type="checkbox"
                      checked={watchUpdate.isDiscounted}
                      onChange={(e) => setWatchUpdate((prev) => ({ ...prev, isDiscounted: e.target.checked }))}
                    />
                  </div>

                  <div className="brendUpdateItem">
                    <label>Discount Price</label>
                    <input
                      type="number"
                      placeholder={watchUpdate.discountPrice}
                      className="brendUpdateInput"
                      value={watchUpdate.discountPrice}
                      onChange={(e) => setWatchUpdate((prev) => ({ ...prev, discountPrice: e.target.value }))}
                    />
                  </div>

                  <div className="brendUpdateItem">
                    <label>Gender</label>
                    <select
                      value={watchUpdate.gender}
                      onChange={(e) => setWatchUpdate((prev) => ({ ...prev, gender: e.target.value }))}
                    >
                      {characteristics.genderEnums.map((gender, index) => (
                        <option key={index} value={gender}>{gender}</option>
                      ))}
                    </select>
                  </div>

                  <div className="brendUpdateItem">
                    <label>Guarantee</label>
                    <select
                      value={watchUpdate.guarantee}
                      onChange={(e) => setWatchUpdate((prev) => ({ ...prev, guarantee: e.target.value }))}
                    >
                      {characteristics.guaranteeMonth.map((guarantee, index) => (
                        <option key={index} value={guarantee}>{guarantee}</option>
                      ))}
                    </select>
                  </div>

                  <div className="brendUpdateItem">
                    <label>Time Format</label>
                    <select
                      value={watchUpdate.timeFormat}
                      onChange={(e) => setWatchUpdate((prev) => ({ ...prev, timeFormat: e.target.value }))}
                    >
                      {characteristics.timeFormatEnums.map((timeFormat, index) => (
                        <option key={index} value={timeFormat}>{timeFormat}</option>
                      ))}
                    </select>
                  </div>

                  <div className="brendUpdateItem">
                    <label>Brend</label>
                    <select
                      value={watchUpdate.brendId}
                      onChange={(e) => setWatchUpdate((prev) => ({ ...prev, brendId: parseInt(e.target.value) }))}
                    >
                      {characteristics.brends.map((brend) => (
                        <option key={brend.id} value={brend.id}>{brend.name}</option>
                      ))}
                    </select>
                  </div>

                  <div className="brendUpdateItem">
                    <label>Style</label>
                    <select
                      value={watchUpdate.styleId}
                      onChange={(e) => setWatchUpdate((prev) => ({ ...prev, styleId: parseInt(e.target.value) }))}
                    >
                      {characteristics.styles.map((style) => (
                        <option key={style.id} value={style.id}>{style.name}</option>
                      ))}
                    </select>
                  </div>

                  <div className="brendUpdateItem">
                    <label>Strap Name</label>
                    <select
                      value={watchUpdate.strap.name}
                      onChange={(e) => setWatchUpdate((prev) => ({ ...prev, strap: { ...prev.strap, name: e.target.value } }))}
                    >
                      {characteristics.strapEnums.map((strap, index) => (
                        <option key={index} value={strap}>{strap}</option>
                      ))}
                    </select>
                  </div>

                  <div className="brendUpdateItem">
                    <label>Strap Material</label>
                    <select
                      value={watchUpdate.strap.strapMaterialId}
                      onChange={(e) => setWatchUpdate((prev) => ({ ...prev, strap: { ...prev.strap, strapMaterialId: parseInt(e.target.value) } }))}
                    >
                      {characteristics.strapMaterials.map((strapMaterial) => (
                        <option key={strapMaterial.id} value={strapMaterial.id}>{strapMaterial.name}</option>
                      ))}
                    </select>
                  </div>

                  <div className="brendUpdateItem">
                    <label>Country</label>
                    <select
                      value={watchUpdate.countryId}
                      onChange={(e) => setWatchUpdate((prev) => ({ ...prev, countryId: e.target.value }))}
                    >
                      {characteristics.countries.map((country) => (
                        <option key={country.id} value={country.id}>{country.name}</option>
                      ))}
                    </select>
                  </div>

                  <div className="brendUpdateItem">
                    <label>Mechanism Type</label>
                    <select
                      value={watchUpdate.mechanismTypeId}
                      onChange={(e) => setWatchUpdate((prev) => ({ ...prev, mechanismTypeId: parseInt(e.target.value) }))}
                    >
                      {characteristics.mechanismTypes.map((mechanismType) => (
                        <option key={mechanismType.id} value={mechanismType.id}>{mechanismType.name}</option>
                      ))}
                    </select>
                  </div>

                  <div className="brendUpdateItem">
                    <label>ClockFace Indication Kind</label>
                    <select
                      value={watchUpdate.clockFace.indicationKindId}
                      onChange={(e) => setWatchUpdate((prev) => ({ ...prev, clockFace: { ...prev.clockFace, indicationKindId: parseInt(e.target.value) } }))}
                    >
                      {characteristics.indicationKinds.map((indicationKind) => (
                        <option key={indicationKind.id} value={indicationKind.id}>{indicationKind.name}</option>
                      ))}
                    </select>
                  </div>

                  <div className="brendUpdateItem">
                    <label>ClockFace Indication Type</label>
                    <select
                      value={watchUpdate.clockFace.indicationTypeId}
                      onChange={(e) => setWatchUpdate((prev) => ({ ...prev, clockFace: { ...prev.clockFace, indicationTypeId: parseInt(e.target.value) } }))}
                    >
                      {characteristics.indicationTypes.map((indicationType) => (
                        <option key={indicationType.id} value={indicationType.id}>{indicationType.name}</option>
                      ))}
                    </select>
                  </div>

                  <div className="brendUpdateItem">
                    <label>Glass type</label>
                    <select
                      value={watchUpdate.glassTypeId}
                      onChange={(e) => setWatchUpdate((prev) => ({ ...prev, glassTypeId: parseInt(e.target.value) }))}
                    >
                      {characteristics.glassTypes.map((glassType) => (
                        <option key={glassType.id} value={glassType.id}>{glassType.name}</option>
                      ))}
                    </select>
                  </div>

                  <div className="brendUpdateItem">
                    <label>ClockFace Color</label>
                    <select
                      value={watchUpdate.clockFace.clockFaceColorId}
                      onChange={(e) => setWatchUpdate((prev) => ({ ...prev, clockFace: { ...prev.clockFace, clockFaceColorId: parseInt(e.target.value) } }))}
                    >
                      {characteristics.clockFaceColors.map((clockFaceColor) => (
                        <option key={clockFaceColor.id} value={clockFaceColor.id}>{clockFaceColor.name}</option>
                      ))}
                    </select>
                  </div>

                  <div className="brendUpdateItem">
                    <label>Frame Color</label>
                    <select
                      value={watchUpdate.frame.frameColorId}
                      onChange={(e) => setWatchUpdate((prev) => ({ ...prev, frame: { ...prev.frame, frameColorId: parseInt(e.target.value) } }))}
                    >
                      {characteristics.frameColors.map((frameColor) => (
                        <option key={frameColor.id} value={frameColor.id}>{frameColor.name}</option>
                      ))}
                    </select>
                  </div>

                  <div className="brendUpdateItem">
                    <label>Water Resistance</label>
                    <select
                      value={watchUpdate.frame.waterResistance}
                      onChange={(e) => setWatchUpdate((prev) => ({ ...prev, frame: { ...prev.frame, waterResistance: e.target.value } }))}
                    >
                      {characteristics.waterResistanceEnums.map((waterResistance, index) => (
                        <option key={index} value={waterResistance}>{waterResistance}</option>
                      ))}
                    </select>
                  </div>

                  <div className="brendUpdateItem">
                    <label>Frame Material</label>
                    <select
                      value={watchUpdate.frame.frameMaterialId}
                      onChange={(e) => setWatchUpdate((prev) => ({ ...prev, frame: { ...prev.frame, frameMaterialId: parseInt(e.target.value) } }))}
                    >
                      {characteristics.frameMaterials.map((frameMaterial) => (
                        <option key={frameMaterial.id} value={frameMaterial.id}>{frameMaterial.name}</option>
                      ))}
                    </select>
                  </div>

                  <div className="brendUpdateItem">
                    <label htmlFor="length">Length</label>
                    <input
                      id="length"
                      type="number"
                      className="inputWatchStyle"
                      value={watchUpdate.frame.dimensions.length}
                      onChange={(e) => setWatchUpdate((prev) => ({ ...prev, frame: { ...prev.frame, dimensions: { ...prev.frame.dimensions, length: e.target.value } } }))}
                    />
                  </div>

                  <div className="brendUpdateItem">
                    <label htmlFor="thickness">Thickness</label>
                    <input
                      id="thickness"
                      type="number"
                      className="inputWatchStyle"
                      value={watchUpdate.frame.dimensions.thickness}
                      onChange={(e) => setWatchUpdate((prev) => ({ ...prev, frame: { ...prev.frame, dimensions: { ...prev.frame.dimensions, thickness: e.target.value } } }))}
                    />
                  </div>

                  <div className="brendUpdateItem">
                    <label htmlFor="width">Width</label>
                    <input
                      id="width"
                      type="number"
                      className="inputWatchStyle"
                      value={watchUpdate.frame.dimensions.width}
                      onChange={(e) => setWatchUpdate((prev) => ({ ...prev, frame: { ...prev.frame, dimensions: { ...prev.frame.dimensions, width: e.target.value } } }))}
                    />
                  </div>

                  <div className="brendUpdateItem">
                    <label htmlFor="Weight">Weight</label>
                    <input
                      id="Weight"
                      type="number"
                      className="inputWatchStyle"
                      value={watchUpdate.frame.dimensions.weight}
                      onChange={(e) => setWatchUpdate((prev) => ({ ...prev, frame: { ...prev.frame, dimensions: { ...prev.frame.dimensions, weight: e.target.value } } }))}
                    />
                  </div>

                  <div className="brendUpdateItem">
                    <label>Case Diameter</label>
                    <select
                      id="Diameter"
                      name="Diameter"
                      value={watchUpdate.frame.dimensions.caseDiameter}
                      onChange={(e) => setWatchUpdate((prev) => ({ ...prev, frame: { ...prev.frame, dimensions: { ...prev.frame.dimensions, caseDiameter: e.target.value } } }))}
                    >
                      {characteristics.caseDiameterEnums.map((caseDiameter, index) => (
                        <option key={index} value={caseDiameter}>{caseDiameter}</option>
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