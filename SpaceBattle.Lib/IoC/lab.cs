MovantOptions1
[
    "MoveCommand"
    "RotateCommand"
    "CorrectVelocity"
]

MovantOptions2
[
    "CheckFuelCommand"
    "BurnFuelCommand"
]

IoC.Resolve<ICommand>("Game.Operations.Movement")

