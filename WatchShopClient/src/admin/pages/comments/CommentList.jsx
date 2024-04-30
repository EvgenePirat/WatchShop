import React from 'react'
import '../../styles/comment/commentList.css'
import { DataGrid, GridToolbar } from '@mui/x-data-grid';
import DeleteIcon from '@mui/icons-material/Delete';
import toast, { Toaster } from 'react-hot-toast';
import { useDeleteCommentMutation, useGetCommentsQuery } from '../../../apis/admin/commentApi';

function CommentList() {

    const {data, isLoading} = useGetCommentsQuery(null)
    const [deleteCommentMutation] = useDeleteCommentMutation();

    const columns = [
        { field: 'id', headerName: 'ID', width: 90 },
        { field: 'comment', headerName: 'Comment', width: 150, renderCell: (params) => (params.value ? params.value : '-') },
        { field: 'userId', headerName: 'User', width: 300, renderCell: (params) => (params.value ? params.value : '-') },
        { field: 'watchId', headerName: 'Watch', width: 300, renderCell: (params) => (params.value ? params.value : '-') },
        { field: 'grade', headerName: 'Grade', width: 300, renderCell: (params) => (params.value ? params.value : '-') },
        {
          field: "action",
          headerName: "Action",
          width: 150,
          renderCell: (params) => {
            return (
              <>
                <button onClick={() => handleDeleteComment(params.row.id)}><DeleteIcon className='userListButtonDelete' /></button>
              </>
            )
          }
        }
      ];

      const handleDeleteComment = async (id) => {

        const result = deleteCommentMutation(id)
  
        result.then(response => {
          
          if (response.error) {
            toast.error('Comment is not deleted')
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
    <div className='brendList'>
      <div className='brendTitleContainer'>
        <h3 className="brendTitle">Comments</h3>
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
          components={{
            Toolbar: GridToolbar,
          }}
        />
      </div>
      <Toaster position="bottom-right" reverseOrder={false} />
    </div>
  )
}

export default CommentList
