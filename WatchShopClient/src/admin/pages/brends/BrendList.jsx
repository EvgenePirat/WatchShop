import React, { useEffect } from 'react'
import '../../styles/brend/BrendList.css'
import { DataGrid } from '@mui/x-data-grid';
import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/Delete';
import { Link } from 'react-router-dom';
import { useDeleteBrendMutation, useGetBrendsQuery } from '../../../apis/admin/brendApi';
import toast, { Toaster } from 'react-hot-toast';
import { useNavigate } from 'react-router-dom';

function BrendList() {

  const {data, isLoading} = useGetBrendsQuery(null)
  const [deleteBrendMutation] = useDeleteBrendMutation();
  const navigate = useNavigate();

  const columns = [
    { field: 'id', headerName: 'ID', width: 90 },
    { field: 'name', headerName: 'Name', width: 150 },
    { field: 'description', headerName: 'Description', width: 300 },
    {
      field: "action",
      headerName: "Action",
      width: 150,
      renderCell: (params) => {
        return (
          <>
            <EditIcon className='userListButtonEdit' onClick={() => navigate("/admin/brend/"+params.row.id, {state: {brend: params.row}})} />
            <button onClick={() => handleDeleteBrend(params.row.id)}><DeleteIcon className='userListButtonDelete' /></button>
          </>
        )
      }
    }
  ];

  const handleDeleteBrend = async (id) => {

      const result = deleteBrendMutation(id)

      result.then(response => {
        
        if (response.data.isSuccess) {
          toast.success(response.data.result)
        } else {
          toast.error('brend is not deleted')
        }
      })


  }

  if(isLoading){
    return <div>Loading...</div>
  }

  return (
    <div className='brendList'>
      <div className='brendTitleContainer'>
        <h3 className="brendTitle">Brends</h3>
        <button className='brendAddButton'><Link to="/admin/brend/create">Add New</Link></button>
      </div>
      <div style={{ width: '100%', alignItems: 'end'}}>
        <DataGrid
          rows={data.result}
          columns={columns}
          initialState={{
            pagination: {
              paginationModel: { page: 0, pageSize: 10 },
            },
          }}
          disableRowSelectionOnClick
          pageSizeOptions={[15, 10]}
          checkboxSelection
        />
      </div>
      <Toaster position="bottom-right" reverseOrder={false} />
    </div>
  )
}

export default BrendList