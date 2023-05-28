function returnModifiedCrew(worker){
    if(worker.dizziness){
        worker.levelOfHydrated += 0.1 * Number(worker.experience * worker.weight);
        worker.dizziness = false;
    }
    return worker;
}

returnModifiedCrew({ weight: 80,
    experience: 1,
    levelOfHydrated: 0,
    dizziness: true }
    );
  