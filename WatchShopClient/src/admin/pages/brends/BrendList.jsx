import React from 'react'
import '../../styles/BrendList.css'
import { DataGrid } from '@mui/x-data-grid';
import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/Delete';
import { Link, NavLink } from 'react-router-dom';

const columns = [
  { field: 'id', headerName: 'ID', width: 90 },
  { field: 'name', headerName: 'Name', width: 150 },
  { field: 'description', headerName: 'Description', width: 300 },
  {
    field: 'count',
    headerName: 'count watch',
    type: 'number',
    width: 100,
  },
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

const rows = [
  { id: 1, name: 'Rolex', description: 'Jon', count: 12 },
  { id: 2, name: 'Fossil', description: 'Jon', count: 2 },
  { id: 3, name: 'Omega', description: 'Jon', count: 3 },
  { id: 4, name: 'Cartier', description: 'Jon', count: 45 },
  { id: 5, name: 'Chopard', description: 'Jon', count: 7 },
  { id: 6, name: 'Breguet', description: 'Jon', count: 0 },
  { id: 7, name: 'Angelus', description: 'Jon', count: 2 },
];

function BrendList() {
  return (
    <div className='brendList'>
      <div className='brendTitleContainer'>
        <h3 className="brendTitle">Brends</h3>
        <button className='brendAddButton'><Link to="/admin/brend/create">Add New</Link></button>
      </div>
      <div style={{ width: '100%', alignItems: 'end'}}>
        <DataGrid
          rows={rows}
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