| Description                                          | ParticipantCount | Mean          | Ratio    | Allocated | 
|----------------------------------------------------- |----------------- |--------------:|---------:|----------:|
| SignalAndWait · AsyncCountdownEvent · CountdownEvent | 1                |      7.803 ns |     0.93 |         - | 
| SignalAndWait · AsyncCountdownEvent · Pooled         | 1                |      8.362 ns |     1.00 |         - | 
| SignalAndWait · AsyncCountdownEvent · ProtoPromise   | 1                |      8.439 ns |     1.01 |         - | 
| SignalAndWait · AsyncCountdownEvent · RefImpl        | 1                |     18.323 ns |     2.19 |      96 B | 
| WaitAndSignal · AsyncCountdownEvent · ProtoPromise   | 1                |     24.511 ns |     2.93 |         - | 
| WaitAndSignal · AsyncCountdownEvent · Pooled         | 1                |     54.853 ns |     6.56 |         - | 
| SignalAndWait · AsyncCountdownEvent · DotNext        | 1                | 18,936.179 ns | 2,264.60 |   33471 B | 
|                                                      |                  |               |          |           | 
| SignalAndWait · AsyncCountdownEvent · ProtoPromise   | 10               |     19.609 ns |     0.77 |         - | 
| SignalAndWait · AsyncCountdownEvent · CountdownEvent | 10               |     23.445 ns |     0.92 |         - | 
| SignalAndWait · AsyncCountdownEvent · Pooled         | 10               |     25.622 ns |     1.00 |         - | 
| WaitAndSignal · AsyncCountdownEvent · ProtoPromise   | 10               |     30.990 ns |     1.21 |         - | 
| SignalAndWait · AsyncCountdownEvent · RefImpl        | 10               |     32.884 ns |     1.28 |      96 B | 
| WaitAndSignal · AsyncCountdownEvent · Pooled         | 10               |     70.969 ns |     2.77 |         - | 
| SignalAndWait · AsyncCountdownEvent · DotNext        | 10               | 19,369.994 ns |   755.99 |   33471 B |