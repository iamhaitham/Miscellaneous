import { StatusBar } from "expo-status-bar";
import React, { useState } from "react";
import GoalItem from './components/GoalItem';
import GoalInput from './components/GoalInput';

import { StyleSheet, Text, View, TextInput, Button, ScrollView, FlatList } from "react-native";

export default function App() {
  const [courseGoals, setCourseGoals] = useState([]);

  const addGoalHandler = (enteredGoal) => {
    setCourseGoals(currentGoals => [...currentGoals, {"id":Math.random().toString(),"value":enteredGoal}]);
  };

  const removeGoalHandler = (goalId) => {
    setCourseGoals(currentGoals=>{
      return currentGoals.filter(goal => goal.id!==goalId);
    });
  }

  return (
    <View style={styles.screen}>
      
      <GoalInput onAddGoal={addGoalHandler}/>

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
