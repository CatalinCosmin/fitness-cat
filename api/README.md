<div>
  <div style="padding: 20px; border: 1px solid #ccc;">
    <h2>Running and Restoring a .NET Project</h2>
    <p>To run a .NET project, you can follow these steps:</p>
    <ol>
      <li>Open a terminal or command prompt and navigate to the project directory.</li>
      <li>Run the following command: <code>dotnet run</code>
      </li>
      <li>The project will be compiled and run. You should see the output in the terminal or command prompt.</li>
    </ol>
    <p>To restore a .NET project, you can follow these steps:</p>
    <ol>
      <li>Open a terminal or command prompt and navigate to the project directory.</li>
      <li>Run the following command: <code>dotnet restore</code>
      </li>
      <li>The project will be restored, and any necessary dependencies will be installed.</li>
    </ol>
    <p>These commands assume that you have .NET installed on your machine. If you don't have .NET installed, you can download it from the official website: <a href="https://dotnet.microsoft.com/download">https://dotnet.microsoft.com/download</a>
    </p>
  </div>
  <div style="padding: 20px; border: 1px solid #ccc;">
    <h1>API Endpoints</h1>
    <h2>Authentication</h2>
    <ul>
      <li>
        <strong>Register:</strong>
        <br> POST /Auth/register <br> Request body: RegisterRequestDto <br> Registers a new user and returns the user's ID.
      </li>
      <li>
        <strong>Login:</strong>
        <br> POST /Auth/login <br> Request body: LoginRequestDto <br> Logs in a user and returns a token to authenticate future requests.
      </li>
      <li>
        <strong>Verify Account:</strong>
        <br> POST /Auth/verify_account <br> Request body: IToken <br> Verifies a user's account using a verification token sent to their email.
      </li>
    </ul>
    <h2>Exercises</h2>
    <ul>
      <li>
        <strong>Get All Exercises: <br>
        </strong> GET /Exercises <br> Returns a list of all exercises.
      </li>
      <li>
        <strong>Get Exercise by ID: <br>
        </strong> GET /Exercises/{id} <br> Returns an exercise with the specified ID.
      </li>
    </ul>
    <h2>Muscle Groups</h2>
    <ul>
      <li>
        <strong>Get All Muscle Groups: <br>
        </strong> GET /MuscleGroups <br> Returns a list of all muscle groups.
      </li>
      <li>
        <strong>Get Muscle Group by ID: <br>
        </strong> GET /MuscleGroups/{id} <br> Returns a muscle group with the specified ID.
      </li>
    </ul>
    <h2>Muscles</h2>
    <ul>
      <li>
        <strong>Get All Muscles: <br>
        </strong> GET /Muscles <br> Returns a list of all muscles.
      </li>
      <li>
        <strong>Get Muscle by ID: <br>
        </strong> GET /Muscles/{id} <br> Returns a muscle with the specified ID.
      </li>
    </ul>
    <h2>Workout Routines</h2>
    <ul>
      <li>
        <strong>Get Workout Routine by ID: <br>
        </strong> GET /WorkoutRoutines/{id} <br> Returns a workout routine with the specified ID.
      </li>
      <li>
        <strong>Delete Workout Routine by ID: <br>
        </strong> DELETE /WorkoutRoutines/{id} <br> Deletes a workout routine with the specified ID.
      </li>
      <li>
        <strong>Get All Workout Routines: <br>
        </strong> GET /WorkoutRoutines <br> Returns a list of all workout routines.
      </li>
      <li>
        <strong>Delete Workout from Routine: <br>
        </strong> DELETE /WorkoutRoutines/{workoutRoutineId}/workout/{workoutId} <br> Deletes a workout from a workout routine.
      </li>
      <li>
        <strong>Create Workout Routine: <br>
        </strong> POST /workoutroutine <br> Request body: WorkoutRoutineDto <br> Creates a new workout routine and returns the routine's ID.
      </li>
    </ul>
    <h2>Workouts</h2>
    <ul>
      <li>
        <strong>Get Workout by ID: <br>
        </strong> GET /Workouts/{id} <br> Returns a workout with the specified ID.
      </li>
      <li>
        <strong>Delete Workout by ID: <br>
        </strong> DELETE /Workouts/{id} <br> Deletes a workout with the specified ID.
      </li>
      <li>
        <strong>Get All Workouts: <br>
        </strong> GET /Workouts <br> Returns a list of all workouts.
      </li>
      <li>
        <strong>Create a New Workout: <br>
        </strong> POST /Workouts <br> Creates a new workout with the provided information in the request body.
      </li>
      <li>
        <strong>Delete Exercise from Workout: <br>
        </strong> DELETE /Workouts/{workoutId}/exercises/{exerciseId} <br> Deletes an exercise from a workout with the specified IDs.
      </li>
    </ul>
    <h2>Schemas</h2>
    <ul>
      <li>
        <strong>DateOnly:</strong>
        <br>
        <code> { year: integer($int32), month: integer($int32), day: integer($int32), dayOfWeek: DayOfWeekinteger($int32), dayOfYear: integer($int32), dayNumber: integer($int32) } </code>
      </li>
      <li>
        <strong>DayOfWeekinteger:</strong>
        <br>
        <code> { enum: [ "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" ] } </code>
      </li>
      <li>
        <strong>IToken:</strong>
        <br>
        <code> { token: string } </code>
      </li>
      <li>
        <strong>LoginRequestDto:</strong>
        <br>
        <code> { username: string, email: string, password*: string, recaptcha*: string } </code>
      </li>
      <li>
        <strong>RegisterRequestDto:</strong>
        <br>
        <code> { id: string($uuid), username: string, password: string, email: string, birthDate: DateOnly{...}, accountCreationDate: DateOnly{...}, lastAuthenticationDate: string($date-time), isVerified: boolean, recaptcha*: string } </code>
      </li>
    </ul>
  </div>
</div>