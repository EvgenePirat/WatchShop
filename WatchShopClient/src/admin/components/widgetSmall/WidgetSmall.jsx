import './widgetSmall.css'
import VisibilityIcon from '@mui/icons-material/Visibility';

function WidgetSmall() {
  return (
    <div className='widgetSm'>
      <span className="widgetSmTitle">New Join Members</span>
      <ul className='widgetSmList'>
        <li className='widgetSmListItem'>
            <img src='https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQElWKlvoKhNSd1xxgVK59sgjJgfoA00LuWkrYZv4jyvQ&s' className='widgetSmImg' />
            <div className='widgetSmUser'>
                <span className='widgetSmUsername'>Anna Keller</span>
                <span className='widgetSmTitle'>Software Enginner</span>
            </div>
            <button className="widgetSmButton">
                <VisibilityIcon />
            </button>
        </li>
        <li className='widgetSmListItem'>
            <img src='https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQElWKlvoKhNSd1xxgVK59sgjJgfoA00LuWkrYZv4jyvQ&s' className='widgetSmImg' />
            <div className='widgetSmUser'>
                <span className='widgetSmUsername'>Anna Keller</span>
                <span className='widgetSmTitle'>Software Enginner</span>
            </div>
            <button className="widgetSmButton">
                <VisibilityIcon />
            </button>
        </li>
        <li className='widgetSmListItem'>
            <img src='https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQElWKlvoKhNSd1xxgVK59sgjJgfoA00LuWkrYZv4jyvQ&s' className='widgetSmImg' />
            <div className='widgetSmUser'>
                <span className='widgetSmUsername'>Anna Keller</span>
                <span className='widgetSmTitle'>Software Enginner</span>
            </div>
            <button className="widgetSmButton">
                <VisibilityIcon />
            </button>
        </li>
        <li className='widgetSmListItem'>
            <img src='https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQElWKlvoKhNSd1xxgVK59sgjJgfoA00LuWkrYZv4jyvQ&s' className='widgetSmImg' />
            <div className='widgetSmUser'>
                <span className='widgetSmUsername'>Anna Keller</span>
                <span className='widgetSmTitle'>Software Enginner</span>
            </div>
            <button className="widgetSmButton">
                <VisibilityIcon />
            </button>
        </li>
        <li className='widgetSmListItem'>
            <img src='https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQElWKlvoKhNSd1xxgVK59sgjJgfoA00LuWkrYZv4jyvQ&s' className='widgetSmImg' />
            <div className='widgetSmUser'>
                <span className='widgetSmUsername'>Anna Keller</span>
                <span className='widgetSmTitle'>Software Enginner</span>
            </div>
            <button className="widgetSmButton">
                <VisibilityIcon />
            </button>
        </li>
      </ul>
    </div>
  )
}

export default WidgetSmall
