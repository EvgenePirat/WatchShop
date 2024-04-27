import React from 'react'
import './chart.css'
import { LineChart, Line, XAxis, YAxis, CartesianGrid, Tooltip, Legend, ResponsiveContainer } from 'recharts';

function Chart({ title, salesArray, dataKey, grid }) {

  if(!salesArray){
    return <div>Loading...</div>
  }

  return (
    <div className='chart'>
    <h3 className="chartTitle">{title}</h3>
    <ResponsiveContainer width="100%" height={400}>
      <LineChart data={salesArray}>
        <CartesianGrid strokeDasharray="5 5" />
        <XAxis dataKey="date" />
        <YAxis />
        <Tooltip />
        <Line type="monotone" dataKey="sales" stroke="#8884d8" />
      </LineChart>
    </ResponsiveContainer>
  </div>
  )
}

export default Chart