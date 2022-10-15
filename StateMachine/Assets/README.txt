- LineOfSightExample show how you can add abstraction to states to control them within a list.
- Each state is based off a AStateBehaviour which itself is a component and abstract
- Each state is configured on the enemy but this could be applied to anything that would have variou states
- To add extra states you need to add additional entries into the enum associated with that character in Scripts/StateBehaviourSystem/Config/BehaviourStates.cs
  Then Add A StateMachine Component To Said Object, As Well As All Of It's Relevant States, then place them in the array inside the state machine in the same order you set them up in the enum