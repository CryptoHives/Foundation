| Description                                          | ParticipantCount | Mean          | Ratio    | Allocated | 
|----------------------------------------------------- |----------------- |--------------:|---------:|----------:|
| SignalAndWait · AsyncCountdownEvent · ProtoPromise   | 1                |      4.320 ns |     0.76 |         - | 
| SignalAndWait · AsyncCountdownEvent · Pooled         | 1                |      5.679 ns |     1.00 |         - | 
| SignalAndWait · AsyncCountdownEvent · CountdownEvent | 1                |      6.170 ns |     1.09 |         - | 
| SignalAndWait · AsyncCountdownEvent · RefImpl        | 1                |     13.356 ns |     2.35 |      96 B | 
| WaitAndSignal · AsyncCountdownEvent · ProtoPromise   | 1                |     13.977 ns |     2.46 |         - | 
| WaitAndSignal · AsyncCountdownEvent · Pooled         | 1                |     35.192 ns |     6.20 |         - | 
| SignalAndWait · AsyncCountdownEvent · DotNext        | 1                | 14,558.769 ns | 2,563.77 |   32639 B | 
|                                                      |                  |               |          |           | 
| SignalAndWait · AsyncCountdownEvent · CountdownEvent | 10               |     15.096 ns |     0.73 |         - | 
| SignalAndWait · AsyncCountdownEvent · ProtoPromise   | 10               |     15.162 ns |     0.73 |         - | 
| SignalAndWait · AsyncCountdownEvent · Pooled         | 10               |     20.781 ns |     1.00 |         - | 
| SignalAndWait · AsyncCountdownEvent · RefImpl        | 10               |     20.899 ns |     1.01 |      96 B | 
| WaitAndSignal · AsyncCountdownEvent · ProtoPromise   | 10               |     22.532 ns |     1.08 |         - | 
| WaitAndSignal · AsyncCountdownEvent · Pooled         | 10               |     46.539 ns |     2.24 |         - | 
| SignalAndWait · AsyncCountdownEvent · DotNext        | 10               | 14,473.379 ns |   696.51 |   32639 B |