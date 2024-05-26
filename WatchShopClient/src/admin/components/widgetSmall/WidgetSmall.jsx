import './widgetSmall.css'
import VisibilityIcon from '@mui/icons-material/Visibility';
import { useEffect, useState } from 'react';
import { useSelector } from 'react-redux';
import { Link, useNavigate } from 'react-router-dom';
import { formatDate } from '../../../utilities/TransformDate';

function WidgetSmall() {
    const userItems = useSelector(state => state.userItemsStore.userItems);
    const navigate = useNavigate();
    const [latestUserItems, setLatestUserItems] = useState([]);

    useEffect(() => {
        const copiedUserItems = [...userItems];
        
        const sortedUserItems = copiedUserItems.sort((a, b) => {
            return new Date(b.createAccountDate) - new Date(a.createAccountDate);
        });

        setLatestUserItems(sortedUserItems.slice(0, 5));
    }, [userItems]);

    return (
        <div className='widgetSm'>
            <span className="widgetLrTitle">New Join Members</span>
            <ul className='widgetSmList'>
                {latestUserItems.map((user) => (
                    <li className='widgetSmListItem' key={user.id}>
                        <div className='widgetSmUser'>
                            <span className='widgetSmUsername'>{user.userName}</span>
                        </div>
                        <div className='widgetSmUser'>
                            <span className='widgetSmUsername'>{formatDate(user.createAccountDate)}</span>
                        </div>
                        <button className="widgetSmButton">
                            <VisibilityIcon onClick={() => navigate("/admin/user/"+user.id, {state: {user: user}})} />
                        </button>
                    </li>
                ))}
            </ul>
        </div>
    );
}

export default WidgetSmall;
