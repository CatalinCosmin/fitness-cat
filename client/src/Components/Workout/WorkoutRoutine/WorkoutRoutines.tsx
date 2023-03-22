import { useEffect, useState } from "react";
import { Link, useNavigate, useParams } from "react-router-dom";
import { WorkoutRoutineResponse } from "../../../Services/ReponseTypes";
import { GetWorkoutRoutines } from "../../../Services/WorkoutRoutineService";
import Button from 'react-bootstrap/Button';
import Card from 'react-bootstrap/Card';
import Placeholder from 'react-bootstrap/Placeholder';
import "../Workout.css";
import { Col, Container, Row } from "react-bootstrap";
import WorkoutRoutineDetails from "./WorkoutRoutineDetails";

const WorkoutRoutines = (props: { token: any, setToken: any }) => {
    const [token, setToken] = [props.token, props.setToken];
    const [workoutRoutines, setWorkoutRoutines] = useState<WorkoutRoutineResponse[]>([]);
    const navigate = useNavigate();
    const { id } = useParams();


    useEffect(() => {
        GetWorkoutRoutines(token, workoutRoutines, setWorkoutRoutines);
    }, []);

    return (
        <>
            {id !== undefined ?
                (<WorkoutRoutineDetails token={token} setToken={setToken} workoutRoutineId={id} />)
                :
                (<div>
                    <h2 className="mx-auto text-center mt-5 sc">Workout Routines</h2>
                    <Container fluid={true} className="ml-5 mt-5 w-auto">
                        <Row xs={workoutRoutines.length} md='auto' lg='auto' sm='auto' xxl='auto'>
                            {workoutRoutines.map(workoutRoutine => (
                                <Col key={workoutRoutine.id}>
                                    <Card className="workout-routine-card" style={{ width: '18rem' }}>
                                        <Card.Body>
                                            <Card.Title className="pc text-truncate">{workoutRoutine.name}</Card.Title>
                                            <Card.Text className="text-muted workout-routine-card-description mt-3">{workoutRoutine.description}</Card.Text>
                                            <Link to={"/workoutroutines/" + workoutRoutine.id}>
                                            <Row><Col xs lg="7"></Col><Col xs lg="3"><Button className="sc-btn">Details</Button></Col></Row>
                                            </Link>
                                        </Card.Body>
                                    </Card>
                                </Col>
                            ))}
                        </Row>
                    </Container>
                </div>
                )}
        </>
    );
}

export default WorkoutRoutines;