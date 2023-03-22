import { useEffect, useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { WorkoutRoutineResponse } from "../../../Services/ReponseTypes";
import { GetWorkoutRoutineDetails } from "../../../Services/WorkoutRoutineService";
import Button from 'react-bootstrap/Button';
import Card from 'react-bootstrap/Card';
import "../Workout.css";
import { Col, Container, Row } from "react-bootstrap";

const WorkoutRoutineDetails = (props: { token: string, setToken: any, workoutRoutineId: any }) => {
    const [token, setToken] = [props.token, props.setToken];
    const [workoutRoutine, setWorkoutRoutine] = useState<WorkoutRoutineResponse | null>(null);
    const navigate = useNavigate();

    useEffect(() => {
        GetWorkoutRoutineDetails(token, workoutRoutine, setWorkoutRoutine, props.workoutRoutineId);
    }, []);

    console.log(workoutRoutine);

    return (
        <>
            <div>
                {/* <h2 className="mx-auto text-center mt-5 sc">Workout Routines</h2>
                <Container fluid={true} className="ml-5 mt-5 w-auto">
                    <Row xs={workoutRoutines.length} md='auto' lg='auto' sm='auto' xxl='auto'>
                        {workoutRoutines.map(workoutRoutine => (
                            <Col key={workoutRoutine.id}>
                                <Card className="workout-routine-card" style={{ width: '18rem' }}>
                                    <Card.Body>
                                        <Card.Title className="pc text-truncate">{workoutRoutine.name}</Card.Title>
                                        <Card.Text className="workout-routine-card-description mt-3">{workoutRoutine.description}</Card.Text>
                                        <Button variant="primary" className="sc-btn">Go to details</Button>
                                    </Card.Body>
                                </Card>
                            </Col>
                        ))}
                    </Row>
                </Container> */}
                {workoutRoutine !== null &&
                    <div key={workoutRoutine.id}>
                        <h2 className="mx-auto text-center mt-5 sc">{workoutRoutine.name}</h2>
                        <Container fluid={true} className="ml-5 mt-5 w-auto">
                            <Row xs={workoutRoutine.workouts.length} md='auto' lg='auto' sm='auto' xxl='auto'>
                                {workoutRoutine.workouts.map(workout => (
                                    <Col key={workout.id}>
                                        <Card className="workout-routine-card" style={{ width: '18rem' }}>
                                            <Card.Body>
                                                <Card.Title className="pc text-truncate">{workout.name}</Card.Title>
                                                <div className="mt-3 mb-3">
                                                    {workout.exercises.map(exercise => (
                                                        <Card.Text key={exercise.id} className="text-muted pc text-truncate mb-2">{exercise.name}</Card.Text>
                                                    ))}
                                                </div>
                                                <Link to={"/workouts/" + workoutRoutine.id}>
                                                    <Row><Col xs lg="7"></Col><Col xs lg="3"><Button className="sc-btn">Details</Button></Col></Row>
                                                </Link>
                                            </Card.Body>
                                        </Card>
                                    </Col>
                                ))}
                            </Row>
                        </Container>
                        {/* <ul>
                            {workoutRoutine.workouts.map(workout => (
                                <li key={workout.id}>
                                    <h3>{workout.name}</h3>
                                    <ul>
                                        {workout.exercises.map(exercise => (
                                            <li key={exercise.id}>
                                                <h4>{exercise.name}</h4>
                                                <ul>
                                                    {exercise.muscleGroups.map(muscleGroup => (
                                                        <li key={muscleGroup.id}>
                                                            { }
                                                        </li>
                                                    ))}
                                                </ul>
                                            </li>
                                        ))}
                                    </ul>
                                </li>
                                
                            ))}
                        </ul> */}
                    </div>
                }
            </div>
        </>
    );
}

export default WorkoutRoutineDetails;