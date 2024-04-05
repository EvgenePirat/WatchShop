import React, { useEffect } from 'react'
import '../../styles/BrendList.css'
import { DataGrid } from '@mui/x-data-grid';
import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/Delete';
import { Link, NavLink } from 'react-router-dom';
import { useGetBrendsQuery } from '../../../apis/admin/brendApi';
import { useDispatch } from 'react-redux';

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
        <Link to={"/admin/user/"+params.row.id}>
          <EditIcon className='userListButtonEdit' />
        </Link>
          <DeleteIcon className='userListButtonDelete' />
        </>
      )
    }
  }
];
function BrendList() {

  const {data, isLoading} = useGetBrendsQuery(null)

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
              paginationModel: { page: 0, pageSize: 15 },
            },
          }}
          pageSizeOptions={[15, 10]}
          checkboxSelection
        />
      </div>
    </div>
  )
}

export default BrendList