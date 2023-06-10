import React, { useMemo, useState, useEffect } from 'react';
import { useNavigate } from "react-router-dom";
import {
    AreaChart, BarChart,
    Line, Area,
    XAxis,
    YAxis,
    CartesianGrid,
    Tooltip,
    Legend
} from "recharts";
import { httpService } from './Services/httpService';

const Report = () => {
    const [tableData, setTableData] = useState([]);
    const navigate = useNavigate();
    useEffect(() => {       
        getReportData('all');
    }, []);
    const getReportData = async (region) => {
        var data = await httpService.GetReportData(region);
        setTableData(data);
    }
    let handleChange = async(e) => {
        var data = await httpService.GetReportData(e.target.value);
        setTableData(data);
    }
    return (
        <>
        <a style={{float:'right'}} onClick={()=>{navigate('/')}}>PolicyDetails</a><br></br>
            <select style={{padding:'5px',margin: '20px'}}
                onChange={(e) => handleChange(e)}            >
                <option value="all">All regions</option>
                <option value="South">South</option>
                <option value="North">North</option>
                <option value="East">East</option>
                <option value="West">West</option>
            </select>
<br></br>
            <AreaChart
                width={500}
                height={300}
                data={tableData}
                margin={{
                    top: 5,
                    right: 30,
                    left: 20,
                    bottom: 5
                }}
            >
                <CartesianGrid strokeDasharray="3 3" />
                <XAxis dataKey="date" />
                <YAxis />
                <Tooltip />
                <Legend />
                <Area type="monotone" dataKey="count" stroke="#8884d8" fill="#8884d8" />
            </AreaChart>
        </>
    );
}

export default Report;
