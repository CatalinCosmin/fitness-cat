import axios from "axios";
import { useEffect } from "react";
import { ApiUrl } from "./Data";
import { WorkoutRoutineResponse } from "./ReponseTypes";

const url = ApiUrl() + 'workoutRoutines/';

export const GetWorkoutRoutines = async (token: string, workoutRoutinesAux: any, setWorkoutRoutinesAux: any) => {
    const [workoutRoutines, setWorkoutRoutines] = [workoutRoutinesAux, setWorkoutRoutinesAux];

    axios.get<WorkoutRoutineResponse[]>(url)
        .then((res) => {
            if (res.status === 200) {
                setWorkoutRoutines(res.data);
            }
        })
}

export const GetWorkoutRoutineDetails = async (token: string, workoutRoutineAux: WorkoutRoutineResponse | null, setWorkoutRoutineAux: any, workoutRoutineId: string) => {
    const [workoutRoutine, setWorkoutRoutine] = [workoutRoutineAux, setWorkoutRoutineAux];

    axios.get<WorkoutRoutineResponse>(url + workoutRoutineId)
        .then((res) => {
            if (res.status === 200) {
                setWorkoutRoutine(res.data);
            }
        })
}