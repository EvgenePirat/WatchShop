import React from 'react'
import "../../styles/createBrend.css"

function CreateBrend() {
  return (
    <div className='createBrend'>
        <div className="newBrend">
            <h1 className="addBrendTitle">New Brend</h1>
            <form className="addBrendForm">
                <div className="addBrendItem">
                    <label>Name</label>
                    <input type="text" placeholder="Rolex" className='inputBrendStyle' />
                </div>
                <div className="addBrendItem">
                    <label>Description</label>
                    <textarea type="text" placeholder="Was created ....." className='textAreaBrendStyle' />
                </div>
                <div className='brendContainerButtons'>
                    <button className="addBrendButton">Create</button>
                    <button className="backBrendButton">Back</button>
                </div>
            </form>
        </div>
    </div>
  )
}

export default CreateBrend