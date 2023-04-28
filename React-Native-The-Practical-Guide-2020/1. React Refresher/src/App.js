import './App.css';
import GoalDisplayer from '../src/components/GoalDisplayer';
import React,{useState} from 'react';

function App() {
  const [myGoals, setMyGoals] = useState([
    {
      "id":1,
      "name":"Finish React Refresher"
    },
    {
      "id":2,
      "name":"Start React Native"
    }])

    const addAGoal=(goalId,goalName)=>{
      setMyGoals((myGoals)=>{
        return myGoals.concat([{"id":goalId,"name":goalName}])
      })
    }

    return (
    <div className="App">
      <GoalDisplayer goalList={myGoals} addingGoal={addAGoal}/>
    </div>
  );
}

export default App;
