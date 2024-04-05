import React, { useState } from 'react'
import "../../styles/createBrend.css"
import { useAddNewBrendMutation } from '../../../apis/admin/brendApi';
import { Link } from 'react-router-dom';
import toast, { Toaster } from 'react-hot-toast';
import { useNavigate } from 'react-router-dom';

function CreateBrend() {
    const navigate = useNavigate();
    const[name, setName] = useState("");
    const[description, setDescription] = useState("");

    const [addNewBrendMutation] = useAddNewBrendMutation();

    const handleSubmit = async (e) => {
        e.preventDefault();

        const resultOperation = await addNewBrendMutation({name,description});

        if(resultOperation.data.isSuccess)
            toast.success('Brend is add');
        else
            toast.error('Brend is not add');
    
        setName("");
        setDescription("");
    };

  return (
    <div className='createBrend'>
        <div className="newBrend">
            <h1 className="addBrendTitle">New Brend</h1>
            <form className="addBrendForm" onSubmit={handleSubmit}>
                <div className="addBrendItem">
                    <p>Name</p>
                    <input type="text" placeholder="Rolex" className='inputBrendStyle' value={name} onChange={(e) => setName(e.target.value)} />
                </div>
                <div className="addBrendItem">
                    <p>Description</p>
                    <textarea type="text" placeholder="Was created ....." className='textAreaBrendStyle' value={description} onChange={(e) => setDescription(e.target.value)}  />
                </div>
                <div className='brendContainerButtons'>
                    <button className="addBrendButton">Create</button>
                    <button className="backBrendButton" onClick={() => navigate("/admin/brends")}> Back</button>
                </div>
            </form>
        </div>
        <Toaster position="bottom-right" reverseOrder={false} />
    </div>
  )
}

export default CreateBrend