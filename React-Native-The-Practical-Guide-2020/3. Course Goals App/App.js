import { StatusBar } from "expo-status-bar";
import React, { useState } from "react";
import GoalItem from './components/GoalItem';
import GoalInput from './components/GoalInput';

import { StyleSheet, View, Button, FlatList } from "react-native";

export default function App() {
  const [courseGoals, setCourseGoals] = useState([]);
  const [isAddMode,setIsAddMode] = useState(false);

  const addGoalHandler = (enteredGoal) => {
    setCourseGoals(currentGoals => [...currentGoals, {"id":Math.random().toString(),"value":enteredGoal}]);
    setIsAddMode(false);
  };

  const removeGoalHandler = (goalId) => {
    setCourseGoals(currentGoals=>{
      return currentGoals.filter(goal => goal.id!==goalId);
    });
  }

  const cancelGoalAdditionHandler = () =>{
    setIsAddMode(false);
  }

  return (
    <View style={styles.screen}>
      <Button title="Add New Goal" onPress={()=>setIsAddMode(true)}></Button>
      <GoalInput isVisible={isAddMode} onAddGoal={addGoalHandler} onCancel={cancelGoalAdditionHandler}/>
      <FlatList 
        data={courseGoals} 
        keyExtractor={(item,index)=>item.id}
        renderItem={({item})=> <GoalItem title={item.value} id={item.id} onDelete={removeGoalHandler}/> }
      />
    </View>
  );
}

const styles = StyleSheet.create({
  screen: {
    padding: 50,
  }
});
