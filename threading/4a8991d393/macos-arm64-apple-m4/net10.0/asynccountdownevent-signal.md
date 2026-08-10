| Description                                          | ParticipantCount | Mean      | Ratio | Allocated | 
|----------------------------------------------------- |----------------- |----------:|------:|----------:|
| SignalAndWait · AsyncCountdownEvent · ProtoPromise   | 1                |  4.300 ns |  0.75 |         - | 
| SignalAndWait · AsyncCountdownEvent · Pooled         | 1                |  5.710 ns |  1.00 |         - | 
| SignalAndWait · AsyncCountdownEvent · CountdownEvent | 1                |  6.747 ns |  1.18 |         - | 
| SignalAndWait · AsyncCountdownEvent · RefImpl        | 1                | 13.488 ns |  2.36 |      96 B | 
| WaitAndSignal · AsyncCountdownEvent · ProtoPromise   | 1                | 14.059 ns |  2.46 |         - | 
| WaitAndSignal · AsyncCountdownEvent · Pooled         | 1                | 35.945 ns |  6.30 |         - | 
|                                                      |                  |           |       |           | 
| SignalAndWait · AsyncCountdownEvent · ProtoPromise   | 10               | 15.300 ns |  0.70 |         - | 
| SignalAndWait · AsyncCountdownEvent · CountdownEvent | 10               | 16.567 ns |  0.76 |         - | 
| SignalAndWait · AsyncCountdownEvent · RefImpl        | 10               | 21.166 ns |  0.97 |      96 B | 
| SignalAndWait · AsyncCountdownEvent · Pooled         | 10               | 21.840 ns |  1.00 |         - | 
| WaitAndSignal · AsyncCountdownEvent · ProtoPromise   | 10               | 22.773 ns |  1.04 |         - | 
| WaitAndSignal · AsyncCountdownEvent · Pooled         | 10               | 47.524 ns |  2.18 |         - |