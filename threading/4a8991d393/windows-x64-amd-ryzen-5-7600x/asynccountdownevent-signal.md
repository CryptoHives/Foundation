| Description                                          | ParticipantCount | Mean      | Ratio | Allocated | 
|----------------------------------------------------- |----------------- |----------:|------:|----------:|
| SignalAndWait · AsyncCountdownEvent · CountdownEvent | 1                |  7.100 ns |  0.94 |         - | 
| SignalAndWait · AsyncCountdownEvent · Pooled         | 1                |  7.555 ns |  1.00 |         - | 
| SignalAndWait · AsyncCountdownEvent · ProtoPromise   | 1                |  8.125 ns |  1.08 |         - | 
| SignalAndWait · AsyncCountdownEvent · RefImpl        | 1                | 16.252 ns |  2.15 |      96 B | 
| WaitAndSignal · AsyncCountdownEvent · ProtoPromise   | 1                | 18.927 ns |  2.51 |         - | 
| WaitAndSignal · AsyncCountdownEvent · Pooled         | 1                | 46.630 ns |  6.17 |         - | 
|                                                      |                  |           |       |           | 
| SignalAndWait · AsyncCountdownEvent · ProtoPromise   | 10               | 17.174 ns |  0.75 |         - | 
| SignalAndWait · AsyncCountdownEvent · CountdownEvent | 10               | 20.349 ns |  0.88 |         - | 
| SignalAndWait · AsyncCountdownEvent · Pooled         | 10               | 23.020 ns |  1.00 |         - | 
| SignalAndWait · AsyncCountdownEvent · RefImpl        | 10               | 28.449 ns |  1.24 |      96 B | 
| WaitAndSignal · AsyncCountdownEvent · ProtoPromise   | 10               | 28.573 ns |  1.24 |         - | 
| WaitAndSignal · AsyncCountdownEvent · Pooled         | 10               | 61.748 ns |  2.68 |         - |