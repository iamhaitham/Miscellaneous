import React,{useState} from 'react'

const GoalDisplayer = (props) => {
    const {goalList,addingGoal} = props;
    const [myName,setMyName]= useState("");
    const [myId,setMyId]= useState(0);

    const formSubmitHandler = (e) =>{
        e.preventDefault();
        addingGoal(myId,myName);
        setMyName("");
        setMyId("");
    }

    return (
        <>
            <ul>
                {goalList.map((goal)=>
                    <li key={goal.id}>{goal.name}</li>
                )}
            </ul>
            
            <form onSubmit={(e)=>formSubmitHandler(e)}>
                <input type="text" placeholder="Enter id" value={myId} onChange={(e)=>setMyId(e.target.value)}/>
                <input type="text" placeholder="Enter goal name" value={myName} onChange={(e)=>setMyName(e.target.value)}/>
                <input type="submit" value="Add" />
            </form>
        </>
    )
}

export default GoalDisplayer
