import React from 'react'

const ProductDescTabPane = ({watch}) => {

  console.log(watch)

  return (
    <div className="fz-product-details__describtion">

        {watch.description && <p>{watch.description}</p>}

        <h4>Model</h4>
        <ul>
            <li>{watch.nameModel}</li>
        </ul>

        <h4>Strap</h4>
        <ul>
            <li>Type: {watch.strap.name}</li>
            <li>Material: {watch.strap.strapMaterial.name}</li>
        </ul>

        <h4>MechanismType</h4>
        <ul>
            <li>{watch.mechanismType.name}</li>
        </ul>

        <h4>Brend</h4>
        <ul>
            <li>{watch.brend.name}</li>
        </ul>

        <h4>Face</h4>
        <ul>
            <li>Color: {watch.clockFace.clockFaceColor.name}</li>
            <li>Kind: {watch.clockFace.indicationKind.name}</li>
            <li>Type: {watch.clockFace.indicationType.name}</li>
        </ul> 

        <h4>Country</h4>
        <ul>
            <li>{watch.country.name}</li>
        </ul>

        <h4>Frame</h4>
        <ul>
            <li>Case Shape: {watch.frame.caseShape}</li>
            <li>Diameter: {watch.frame.dimensions.caseDiameter}</li>
            <li>Length: {watch.frame.dimensions.length}</li>
            <li>Thickness: {watch.frame.dimensions.thickness}</li>
            <li>Weight: {watch.frame.dimensions.weight}</li>
            <li>Width: {watch.frame.dimensions.width}</li>
            <li>Color: {watch.frame.frameColor.name}</li>
            <li>Material: {watch.frame.frameMaterial.name}</li>
            <li>{watch.frame.waterResistance}</li>
        </ul> 

        <h4>Gender</h4>
        <ul>
            <li>{watch.gender}</li>
        </ul>

        <h4>Glass Type</h4>
        <ul>
            <li>{watch.glassType.name}</li>
        </ul>

        <h4>Guarantee</h4>
        <ul>
            <li>{watch.guarantee}</li>
        </ul>

        <h4>Style</h4>
        <ul>
            <li>{watch.style.name}</li>
        </ul>

        <h4>Time Format</h4>
        <ul>
            <li>{watch.timeFormat}</li>
        </ul>

    </div>
  )
}

export default ProductDescTabPane