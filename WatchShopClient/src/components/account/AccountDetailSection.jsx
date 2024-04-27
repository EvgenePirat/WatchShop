import { Nav, Tab } from 'react-bootstrap';
import AccountOrdersTabPane from './AccountOrdersTabPane';
import AccountDescTabPane from './AccountDescTabPane';
import { useState, useEffect } from 'react';
import { useGetUserByIdQuery } from '../../apis/admin/userApi';


const AccountDetailSection = ({id}) => {

     const {data, isLoading} = useGetUserByIdQuery(id);
     const [user, setUser] = useState();

    useEffect(() => {
        if (!isLoading && data) {
          setUser(data.result);
        }
    }, [data, isLoading]);

    const [activeTab, setActiveTab] = useState('description');

    const handleTabChange = (tab) => {
        setActiveTab(tab);
    };

  return (
    <section className="fz-product-details">
        <div className="container">
            <div className="row align-items-start justify-content-center">
                <div className="col-12">
                    <div className="fz-product-details__additional-info">
                        <Nav 
                        activeKey={activeTab}
                        onSelect={handleTabChange}
                        className="nav nav-tabs" 
                        id="myTab"
                        >
                            <Nav.Item className="nav-item" role="presentation">
                                <Nav.Link 
                                    className="nav-link" 
                                    eventKey='description'
                                    id="descr-tab" 
                                    role="button"
                                >
                                    Account
                                </Nav.Link>
                            </Nav.Item>
                            <Nav.Item className="nav-item" role="presentation">
                                <Nav.Link 
                                    className="nav-link" 
                                    eventKey='review'
                                    id="review-tab" 
                                    role="button"
                                >
                                    Orders
                                </Nav.Link>
                            </Nav.Item>
                        </Nav>
                        <Tab.Content>
                            <Tab.Pane eventKey='description' className={`tab-pane ${activeTab === 'description' ? 'show active' : ''}`}>
                                <AccountDescTabPane user={user} />
                            </Tab.Pane>


                            <Tab.Pane eventKey='review' className={`tab-pane ${activeTab === 'review' ? 'show active' : ''}`}>
                                <AccountOrdersTabPane user={user} />
                            </Tab.Pane>
                        </Tab.Content>
                    </div>
                </div>
            </div>
        </div>
    </section>
  )
}

export default AccountDetailSection