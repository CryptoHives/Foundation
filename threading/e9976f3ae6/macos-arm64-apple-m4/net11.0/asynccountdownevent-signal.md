| Description                                          | ParticipantCount | Mean          | Error      | StdDev     | Ratio    | Allocated | 
|----------------------------------------------------- |----------------- |--------------:|-----------:|-----------:|---------:|----------:|
| SignalAndWait · AsyncCountdownEvent · ProtoPromise   | 1                |      4.159 ns |  0.0181 ns |  0.0169 ns |     0.90 |         - | 
| SignalAndWait · AsyncCountdownEvent · CountdownEvent | 1                |      4.343 ns |  0.0060 ns |  0.0056 ns |     0.94 |         - | 
| SignalAndWait · AsyncCountdownEvent · Pooled         | 1                |      4.612 ns |  0.0139 ns |  0.0130 ns |     1.00 |         - | 
| SignalAndWait · AsyncCountdownEvent · RefImpl        | 1                |     13.948 ns |  0.0479 ns |  0.0425 ns |     3.02 |      96 B | 
| WaitAndSignal · AsyncCountdownEvent · ProtoPromise   | 1                |     15.733 ns |  0.0478 ns |  0.0399 ns |     3.41 |         - | 
| WaitAndSignal · AsyncCountdownEvent · Pooled         | 1                |     37.670 ns |  0.0730 ns |  0.0683 ns |     8.17 |         - | 
| SignalAndWait · AsyncCountdownEvent · DotNext        | 1                | 13,986.521 ns | 53.0666 ns | 44.3130 ns | 3,032.69 |   26449 B | 
|                                                      |                  |               |            |            |          |           | 
| SignalAndWait · AsyncCountdownEvent · ProtoPromise   | 10               |     15.451 ns |  0.0143 ns |  0.0134 ns |     0.82 |         - | 
| SignalAndWait · AsyncCountdownEvent · CountdownEvent | 10               |     16.583 ns |  0.1150 ns |  0.1076 ns |     0.88 |         - | 
| SignalAndWait · AsyncCountdownEvent · Pooled         | 10               |     18.748 ns |  0.0584 ns |  0.0518 ns |     1.00 |         - | 
| SignalAndWait · AsyncCountdownEvent · RefImpl        | 10               |     21.617 ns |  0.0237 ns |  0.0221 ns |     1.15 |      96 B | 
| WaitAndSignal · AsyncCountdownEvent · ProtoPromise   | 10               |     23.252 ns |  0.0159 ns |  0.0149 ns |     1.24 |         - | 
| WaitAndSignal · AsyncCountdownEvent · Pooled         | 10               |     49.922 ns |  0.1112 ns |  0.1040 ns |     2.66 |         - | 
| SignalAndWait · AsyncCountdownEvent · DotNext        | 10               | 13,976.682 ns | 81.6073 ns | 76.3355 ns |   745.52 |   26449 B |