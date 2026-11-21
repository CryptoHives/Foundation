| Description                                          | ParticipantCount | Mean         | Error      | StdDev     | Ratio    | Allocated | 
|----------------------------------------------------- |----------------- |-------------:|-----------:|-----------:|---------:|----------:|
| SignalAndWait · AsyncCountdownEvent · ProtoPromise   | 1                |     21.65 ns |   0.079 ns |   0.146 ns |     1.00 |         - | 
| SignalAndWait · AsyncCountdownEvent · Pooled         | 1                |     21.66 ns |   0.351 ns |   0.651 ns |     1.00 |         - | 
| SignalAndWait · AsyncCountdownEvent · CountdownEvent | 1                |     25.01 ns |   0.008 ns |   0.015 ns |     1.16 |         - | 
| SignalAndWait · AsyncCountdownEvent · RefImpl        | 1                |     70.28 ns |   2.497 ns |   5.268 ns |     3.25 |      96 B | 
| WaitAndSignal · AsyncCountdownEvent · ProtoPromise   | 1                |     77.91 ns |   1.158 ns |   2.174 ns |     3.60 |         - | 
| WaitAndSignal · AsyncCountdownEvent · Pooled         | 1                |    133.61 ns |   0.489 ns |   0.907 ns |     6.17 |         - | 
| SignalAndWait · AsyncCountdownEvent · DotNext        | 1                | 41,481.36 ns | 191.356 ns | 359.414 ns | 1,916.81 |   26600 B | 
|                                                      |                  |              |            |            |          |           | 
| SignalAndWait · AsyncCountdownEvent · ProtoPromise   | 10               |     98.28 ns |   0.095 ns |   0.181 ns |     0.98 |         - | 
| SignalAndWait · AsyncCountdownEvent · Pooled         | 10               |    100.29 ns |   0.186 ns |   0.349 ns |     1.00 |         - | 
| SignalAndWait · AsyncCountdownEvent · CountdownEvent | 10               |    110.39 ns |   0.028 ns |   0.053 ns |     1.10 |         - | 
| WaitAndSignal · AsyncCountdownEvent · ProtoPromise   | 10               |    148.93 ns |   5.469 ns |  10.272 ns |     1.49 |         - | 
| SignalAndWait · AsyncCountdownEvent · RefImpl        | 10               |    152.95 ns |   2.032 ns |   3.817 ns |     1.53 |      96 B | 
| WaitAndSignal · AsyncCountdownEvent · Pooled         | 10               |    213.11 ns |   1.027 ns |   1.905 ns |     2.13 |         - | 
| SignalAndWait · AsyncCountdownEvent · DotNext        | 10               | 41,564.90 ns | 102.975 ns | 193.412 ns |   414.46 |   26600 B |