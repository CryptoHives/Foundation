| Description                                          | ParticipantCount | Mean         | Ratio    | Allocated | 
|----------------------------------------------------- |----------------- |-------------:|---------:|----------:|
| SignalAndWait · AsyncCountdownEvent · ProtoPromise   | 1                |     24.71 ns |     0.99 |         - | 
| SignalAndWait · AsyncCountdownEvent · Pooled         | 1                |     24.99 ns |     1.00 |         - | 
| SignalAndWait · AsyncCountdownEvent · CountdownEvent | 1                |     28.26 ns |     1.13 |         - | 
| SignalAndWait · AsyncCountdownEvent · RefImpl        | 1                |     65.57 ns |     2.62 |      96 B | 
| WaitAndSignal · AsyncCountdownEvent · ProtoPromise   | 1                |     79.92 ns |     3.20 |         - | 
| WaitAndSignal · AsyncCountdownEvent · Pooled         | 1                |    138.90 ns |     5.56 |         - | 
| SignalAndWait · AsyncCountdownEvent · DotNext        | 1                | 43,542.79 ns | 1,742.32 |   33492 B | 
|                                                      |                  |              |          |           | 
| SignalAndWait · AsyncCountdownEvent · Pooled         | 10               |    102.42 ns |     1.00 |         - | 
| SignalAndWait · AsyncCountdownEvent · ProtoPromise   | 10               |    103.18 ns |     1.01 |         - | 
| SignalAndWait · AsyncCountdownEvent · CountdownEvent | 10               |    116.95 ns |     1.14 |         - | 
| WaitAndSignal · AsyncCountdownEvent · ProtoPromise   | 10               |    139.56 ns |     1.36 |         - | 
| SignalAndWait · AsyncCountdownEvent · RefImpl        | 10               |    150.54 ns |     1.47 |      96 B | 
| WaitAndSignal · AsyncCountdownEvent · Pooled         | 10               |    217.61 ns |     2.12 |         - | 
| SignalAndWait · AsyncCountdownEvent · DotNext        | 10               | 44,021.32 ns |   429.82 |   33492 B |