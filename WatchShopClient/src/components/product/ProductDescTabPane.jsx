import React from 'react'
import { transformString } from '../../utilities/TransformString'

const ProductDescTabPane = ({watch, additionalCharacteristics}) => {

    if(!additionalCharacteristics && additionalCharacteristics.length == 0){
        return <div>Loading...</div>
    }
  
  return (
    <div className="fz-product-details__describtion">

        {watch.description && <p>{watch.description}</p>}

        <h4>Model</h4>
        <ul>
            <li>{watch.nameModel}</li>
        </ul>

        <h4>Strap</h4>
        <ul>
            <li>Type: {transformString(watch.strap.name)}</li>
            <li>Material: {transformString(watch.strap.strapMaterial.name)}</li>
        </ul>

        <h4>MechanismType</h4>
        <ul>
            <li>{transformString(watch.mechanismType.name)}</li>
        </ul>

        <h4>Brend</h4>
        <ul>
            <li>{transformString(watch.brend.name)}</li>
        </ul>

        <h4>Face</h4>
        <ul>
            <li>Color: {transformString(watch.clockFace.clockFaceColor.name)}</li>
            <li>Kind: {transformString(watch.clockFace.indicationKind.name)}</li>
            <li>Type: {transformString(watch.clockFace.indicationType.name)}</li>
        </ul> 

        <h4>Country</h4>
        <ul>
            <li>{transformString(watch.country.name)}</li>
        </ul>

        <h4>Frame</h4>
        <ul>
            <li>Case Shape: {transformString(watch.frame.caseShape)}</li>
            <li>Diameter: {transformString(watch.frame.dimensions.caseDiameter)}</li>
            <li>Length: {watch.frame.dimensions.length}</li>
            <li>Thickness: {watch.frame.dimensions.thickness}</li>
            <li>Weight: {watch.frame.dimensions.weight}</li>
            <li>Width: {watch.frame.dimensions.width}</li>
            <li>Color: {transformString(watch.frame.frameColor.name)}</li>
            <li>Material: {transformString(watch.frame.frameMaterial.name)}</li>
            <li>Water Resistance: {transformString(watch.frame.waterResistance)}</li>
        </ul> 

        <h4>Gender</h4>
        <ul>
            <li>{watch.gender}</li>
        </ul>

        <h4>Glass Type</h4>
        <ul>
            <li>{transformString(watch.glassType.name)}</li>
        </ul>

        <h4>Guarantee</h4>
        <ul>
            <li>{transformString(watch.guarantee)}</li>
        </ul>

        <h4>Style</h4>
        <ul>
            <li>{watch.style.name}</li>
        </ul>

        <h4>Time Format</h4>
        <ul>
            <li>{transformString(watch.timeFormat)}</li>
        </ul>

        <h4>Additional Characteristics</h4>
        <ul>
            {watch.watchAdditionalCharacteristics.map((additionalCharacteristic) => {
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
  )
}

export default ProductDescTabPane