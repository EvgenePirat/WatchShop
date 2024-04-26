import React from 'react'
import AccountOrderTable from './AccountOrderTable'

function AccountOrdersTabPane({user}) {

  return (
    <div>
        <div className="container">
          <div className="cart-section">
              <div className="cart-left inner-cart">
                  <div className="cart-area">
                      <div className="cart__body">
                          <div className="table-responsive">
                              <AccountOrderTable user={user}  />
                          </div>
                      </div>
                  </div>
              </div>
          </div>
      </div>
    </div>
  )
}

export default AccountOrdersTabPane