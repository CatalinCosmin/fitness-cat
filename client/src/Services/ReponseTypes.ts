export type ExerciseResponse = {
    id: number;
    name: string;
    muscleGroups: any[];
}

export type WorkoutResponse = {
    id: string;
    name: string;
    description: string;
    exercises: ExerciseResponse[];
}

export type WorkoutRoutineResponse = {
    id: string;
    name: string;
    description: string;
    workouts: WorkoutResponse[];
}