import React from 'react'
import '../../styles/user/userList.css'
import { DataGrid } from '@mui/x-data-grid';
import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/Delete';
import { Link } from 'react-router-dom';
import { useDeleteUserMutation, useGetUsersQuery } from '../../../apis/admin/userApi';
import { useNavigate } from 'react-router-dom';
import toast, { Toaster } from 'react-hot-toast';

function UserList() {

  const {data, isLoading} = useGetUsersQuery(null)
  const [deleteUserMutation] = useDeleteUserMutation();
  const navigate = useNavigate();

  
const columns = [
  { field: 'id', headerName: 'ID', width: 90 },
  { field: 'userName', headerName: 'Username', width: 150 },
  { field: 'fullName', headerName: 'Full name', width: 170, renderCell: (params) => (params.value ? params.value : '-') },
  { field: 'email', headerName: 'Email', width: 130, renderCell: (params) => (params.value ? params.value : '-') },
  { field: 'city', headerName: 'City', width: 100, renderCell: (params) => (params.value ? params.value : '-') },
  { field: 'role', headerName: 'Role', width: 80 },
  {
    field: "action",
    headerName: "Action",
    width: 150,
    renderCell: (params) => {
      return (
        <>
          <EditIcon className='userListButtonEdit' onClick={() => navigate("/admin/user/"+params.row.id, {state: {user: params.row}})} />
          <button onClick={() => handleDeleteUser(params.row.id)}><DeleteIcon className='userListButtonDelete' /></button>
        </>
      )
    }
  }
];

  const handleDeleteUser = async (id) => {

    const result = deleteUserMutation(id)

    result.then(response => {
      
      if (response.data.isSuccess) {
        toast.success(response.data.result)
      } else {
        toast.error('user is not deleted')
      }
    })
  }

  if(isLoading){
    return <div>Loading...</div>
  }else{
    console.log(data)
  }

  return (
    <div className='userList'>
    <div className='userTitleContainer'>
      <h3 className="userTitle">Users</h3>
      <button className='userAddButton'><Link to="/admin/user/create">Add New</Link></button>
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

export default UserList
