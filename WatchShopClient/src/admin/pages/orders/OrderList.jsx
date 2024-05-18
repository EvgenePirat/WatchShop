import React from 'react'
import '../../styles/order/orderList.css'
import { useDeleteOrderMutation, useGetOrdersQuery } from '../../../apis/admin/orderApi'
import toast, { Toaster } from 'react-hot-toast';
import { DataGrid } from '@mui/x-data-grid';
import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/Delete';
import { useNavigate } from 'react-router-dom';

function OrderList() {

    const navigate = useNavigate();
    const {data, isLoading} = useGetOrdersQuery(null);
    const [deleteOrderMutation] = useDeleteOrderMutation();

    const columns = [
        { field: 'id', headerName: 'ID', width: 200 },
        { field: 'createDate', headerName: 'Create Date', width: 220 },
        { field: 'sum', headerName: 'Sum', width: 70 },
        { field: 'userId', headerName: 'UserId', width: 160 },
        { field: 'orderStatus', headerName: 'Status', width: 80, valueGetter:(value, row) => `${row.orderStatus.name}` }, 
        { field: 'paymentMethod', headerName: 'Method', width: 100, valueGetter:(value, row) => `${row.payment.paymentMethod}` }, 
        { field: 'paymentStatus', headerName: 'Pay Status', width: 130, valueGetter:(value, row) => `${row.payment.status}` }, 
        {
          field: "action",
          headerName: "Action",
          width: 150,
          renderCell: (params) => {
            return (
              <>
                <EditIcon className='userListButtonEdit' onClick={() => navigate("/admin/order/"+params.row.id, {state: {order: params.row}})} />
                <button onClick={() => handleDeleteOrder(params.row.id)}><DeleteIcon className='userListButtonDelete' /></button>
              </>
            )
          }
        }
      ];

    const handleDeleteOrder = async (id) => {

        const result = deleteOrderMutation(id)
  
        result.then(response => {
          
          if (response.error) {
            toast.error('order is not deleted')
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
    <div className='orderList'>
      <div className='userTitleContainer'>
          <h3 className="userTitle">Orders</h3>
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
                autoHeight
                scrollbarSize={1}
                checkboxSelection
                />
        </div>
        <Toaster position="bottom-right" reverseOrder={false} />
    </div>
  )
}

export default OrderList
