import React, { useState } from 'react'
import '../../styles/brend/brend.css'
import { useLocation } from 'react-router-dom';
import { useUpdateBrendMutation } from '../../../apis/admin/brendApi';
import toast, { Toaster } from 'react-hot-toast';

function Brend() {

    const location = useLocation();
    const { brend } = location.state || {};

    const [currentName, setCurrentName] = useState(brend.name)
    const [currentDescription, setCurrentDescription] = useState(brend.description)
    const [updateName, setUpdateName] = useState(brend.name)
    const [updateDescription, setUpdateDescription] = useState(brend.description)
    const [updateBrendMutation] = useUpdateBrendMutation();

    const handleUpdateBrend = async (e) => {
        e.preventDefault();

        var result = await updateBrendMutation({id: brend.id, name: updateName, description: updateDescription});

        if(result.data.isSuccess){
            toast.success('Brend is update');
            setCurrentName(result.data.result.name)
            setCurrentDescription(result.data.result.description)
        }
        else
            toast.error('Brend is not update');
    }

  return (
    <div className='brendAdmin'> 
<div className="brendTitleContainerEdit">
        <h1 className="userTitle">Edit Brend</h1>
      </div>
      <div className="brendContainer">
        <div className="brendShow">
            <span className="userUpdateTitle">Details</span>
          <div className="userShowBottom">
            <span className="brendShowTitle">Brend Name</span>
            <div className="brendShowInfo">
              <span className="brendShowInfoTitle">{currentName}</span>
            </div>
          </div>
          <div className="userShowBottom">
            <span className="brendShowTitle">Brend Description</span>
            <div className="brendShowInfo">
              <span className="brendShowInfoTitle">{currentDescription}</span>
            </div>
          </div>
        </div>
        <div className="brendUpdate">
          <span className="userUpdateTitle">Edit</span>
          <form className="userUpdateForm" onSubmit={handleUpdateBrend}>
            <div className="userUpdateLeft">
              <div className="userUpdateItem">
                <label>Name</label>
                <input
                  type="text"
                  placeholder={brend.name}
                  className="brendUpdateInput"
                  value={updateName}
                  onChange={(e) => setUpdateName(e.target.value)}
                />
              </div>
              <div className="userUpdateItem">
                <label>Description</label>
                <textarea
                  type="text"
                  placeholder={brend.description}
                  className="brendUpdateTextArea"
                  value={updateDescription}
                  onChange={(e) => setUpdateDescription(e.target.value)}
                />
              </div>
              <button className="userUpdateButton">Update</button>
            </div>
          </form>
          <Toaster position="bottom-right" reverseOrder={false} />
        </div>
      </div>

    </div>
  )
}

export default Brend