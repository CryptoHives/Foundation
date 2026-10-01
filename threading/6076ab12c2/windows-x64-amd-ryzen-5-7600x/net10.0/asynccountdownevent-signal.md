| Description                                          | ParticipantCount | Mean          | Ratio    | Allocated | 
|----------------------------------------------------- |----------------- |--------------:|---------:|----------:|
| SignalAndWait · AsyncCountdownEvent · CountdownEvent | 1                |      7.650 ns |     0.90 |         - | 
| SignalAndWait · AsyncCountdownEvent · Pooled         | 1                |      8.517 ns |     1.00 |         - | 
| SignalAndWait · AsyncCountdownEvent · ProtoPromise   | 1                |      9.072 ns |     1.07 |         - | 
| SignalAndWait · AsyncCountdownEvent · RefImpl        | 1                |     18.514 ns |     2.17 |      96 B | 
| WaitAndSignal · AsyncCountdownEvent · ProtoPromise   | 1                |     20.686 ns |     2.43 |         - | 
| WaitAndSignal · AsyncCountdownEvent · Pooled         | 1                |     52.901 ns |     6.21 |         - | 
| SignalAndWait · AsyncCountdownEvent · DotNext        | 1                | 20,103.633 ns | 2,360.39 |   33471 B | 
|                                                      |                  |               |          |           | 
| SignalAndWait · AsyncCountdownEvent · ProtoPromise   | 10               |     19.789 ns |     0.77 |         - | 
| SignalAndWait · AsyncCountdownEvent · CountdownEvent | 10               |     23.167 ns |     0.90 |         - | 
| SignalAndWait · AsyncCountdownEvent · Pooled         | 10               |     25.611 ns |     1.00 |         - | 
| WaitAndSignal · AsyncCountdownEvent · ProtoPromise   | 10               |     32.732 ns |     1.28 |         - | 
| SignalAndWait · AsyncCountdownEvent · RefImpl        | 10               |     33.232 ns |     1.30 |      96 B | 
| WaitAndSignal · AsyncCountdownEvent · Pooled         | 10               |     69.384 ns |     2.71 |         - | 
| SignalAndWait · AsyncCountdownEvent · DotNext        | 10               | 19,856.868 ns |   775.34 |   33472 B |