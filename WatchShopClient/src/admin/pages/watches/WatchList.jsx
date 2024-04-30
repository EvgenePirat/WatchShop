import React from 'react'
import '../../styles/watch/WatchList.css'
import { Link } from 'react-router-dom';
import { useDeleteWatchMutation, useGetWatchesQuery } from '../../../apis/admin/watchApi';
import { useNavigate } from 'react-router-dom';
import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/Delete';
import toast, { Toaster } from 'react-hot-toast';
import { DataGrid } from '@mui/x-data-grid';

function WatchList() {

    const { data, isLoading} = useGetWatchesQuery(null);
    const [deleteWatchMutation] = useDeleteWatchMutation();
    const navigate = useNavigate();

    const columns = [
        { field: 'id', headerName: 'ID', width: 50 },
        { field: 'nameModel', headerName: 'Name Model', width: 100 },
        { field: 'price', headerName: 'Price', width: 80 },
        { field: 'gender', headerName: 'Gender', width: 80 },
        { field: 'guarantee', headerName: 'Guarantee', width: 100 },
        { field: 'timeFormat', headerName: 'Time Format', width: 140 },
        { field: 'style', headerName: 'Style', width: 100, valueGetter:(value, row) => `${row.style.name}` }, 
        { field: 'brend', headerName: 'Brend', width: 100, valueGetter:(value, row) => `${row.brend.name}` }, 
        { field: 'country', headerName: 'Country', width: 130, valueGetter:(value, row) => `${row.country.name}` },  
        { field: 'glassType', headerName: 'Glass Type', width: 100, valueGetter:(value, row) => `${row.glassType.name}` }, 
        { field: 'mechanismType', headerName: 'Mechanism Type', width: 130, valueGetter:(value, row) => `${row.mechanismType.name}` }, 
        { field: 'strap', headerName: 'Strap Name', width: 100, valueGetter:(value, row) => `${row.strap.name}` }, 
        { field: 'strap.strapMaterial', headerName: 'Discount', width: 100, valueGetter:(value, row) => `${row.isDiscounted}` }, 
        {
          field: "action",
          headerName: "Action",
          width: 120,
          renderCell: (params) => {
            return (
              <>
                <EditIcon className='userListButtonEdit' onClick={() => navigate("/admin/watch/"+params.row.id, {state: {brend: params.row}})} />
                <button onClick={() => handleDeleteWatch(params.row.id)}><DeleteIcon className='userListButtonDelete' /></button>
              </>
            )
          }
        }
      ];  
      
      const handleDeleteWatch = async (id) => {

        const result = deleteWatchMutation(id)
  
        result.then(response => {
          
          if (response.error) {
            toast.error('watch is not deleted')
          } else {
            toast.success(response.data.result)
          }
        })
  
  
    }



    if(isLoading){
        return <div>Loading...</div>
    }
    else{
        console.log(data)
    }  

  return (
    <div className='watchList'>
        <div className='watchTitleContainer'>
            <h3 className="watchTitle">Watches</h3>
            <button className='watchAddButton'><Link to="/admin/watch/create">Add Watch</Link></button>
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

export default WatchList