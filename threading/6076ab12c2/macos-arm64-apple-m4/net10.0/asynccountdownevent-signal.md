| Description                                          | ParticipantCount | Mean          | Ratio    | Allocated | 
|----------------------------------------------------- |----------------- |--------------:|---------:|----------:|
| SignalAndWait · AsyncCountdownEvent · ProtoPromise   | 1                |      4.434 ns |     0.78 |         - | 
| SignalAndWait · AsyncCountdownEvent · Pooled         | 1                |      5.681 ns |     1.00 |         - | 
| SignalAndWait · AsyncCountdownEvent · CountdownEvent | 1                |      6.705 ns |     1.18 |         - | 
| WaitAndSignal · AsyncCountdownEvent · ProtoPromise   | 1                |     13.940 ns |     2.45 |         - | 
| SignalAndWait · AsyncCountdownEvent · RefImpl        | 1                |     14.040 ns |     2.47 |      96 B | 
| WaitAndSignal · AsyncCountdownEvent · Pooled         | 1                |     36.493 ns |     6.42 |         - | 
| SignalAndWait · AsyncCountdownEvent · DotNext        | 1                | 14,578.222 ns | 2,566.33 |   32639 B | 
|                                                      |                  |               |          |           | 
| SignalAndWait · AsyncCountdownEvent · ProtoPromise   | 10               |     15.475 ns |     0.74 |         - | 
| SignalAndWait · AsyncCountdownEvent · CountdownEvent | 10               |     16.563 ns |     0.80 |         - | 
| SignalAndWait · AsyncCountdownEvent · Pooled         | 10               |     20.832 ns |     1.00 |         - | 
| SignalAndWait · AsyncCountdownEvent · RefImpl        | 10               |     21.225 ns |     1.02 |      96 B | 
| WaitAndSignal · AsyncCountdownEvent · ProtoPromise   | 10               |     22.843 ns |     1.10 |         - | 
| WaitAndSignal · AsyncCountdownEvent · Pooled         | 10               |     47.926 ns |     2.30 |         - | 
| SignalAndWait · AsyncCountdownEvent · DotNext        | 10               | 14,657.054 ns |   703.62 |   32639 B |