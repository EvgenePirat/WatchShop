import React, {useEffect} from 'react'
import BreadcrumbSection from '../breadcrumb/BreadcrumbSection'
import AccountDetailSection from '../account/AccountDetailSection'
import { useSelector } from 'react-redux';

const AccountMain = () => {
  const userAuth = useSelector(state => state.userAuthStore);

  if (!userAuth.id) {
    return <div>...Loading</div>;
  }

  return (
    <>
      <BreadcrumbSection title={"Account"} current={"Account"} />
      <AccountDetailSection id={userAuth.id} />
    </>
  );
};

export default AccountMain