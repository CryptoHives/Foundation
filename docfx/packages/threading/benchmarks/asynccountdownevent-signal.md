| Description                                     | ParticipantCount | Mean       | Ratio | Allocated | 
|------------------------------------------------ |----------------- |-----------:|------:|----------:|
| SignalAndWait · CountdownEvent · System         | 1                |   6.608 ns |  0.70 |         - | 
| SignalAndWait · AsyncCountdownEv · ProtoPromise | 1                |   7.900 ns |  0.84 |         - | 
| SignalAndWait · AsyncCountdownEv · Pooled       | 1                |   9.421 ns |  1.00 |         - | 
| SignalAndWait · AsyncCountdownEv · RefImpl      | 1                |  16.021 ns |  1.70 |      96 B | 
| WaitAndSignal · AsyncCountdownEv · Pooled       | 1                |  40.293 ns |  4.28 |         - | 
| WaitAndSignal · AsyncCountdownEv · ProtoPromise | 1                | 431.847 ns | 45.84 |     204 B | 
|                                                 |                  |            |       |           | 
| SignalAndWait · AsyncCountdownEv · ProtoPromise | 10               |  17.075 ns |  0.45 |         - | 
| SignalAndWait · CountdownEvent · System         | 10               |  20.162 ns |  0.53 |         - | 
| SignalAndWait · AsyncCountdownEv · RefImpl      | 10               |  28.314 ns |  0.75 |      96 B | 
| SignalAndWait · AsyncCountdownEv · Pooled       | 10               |  37.761 ns |  1.00 |         - | 
| WaitAndSignal · AsyncCountdownEv · Pooled       | 10               |  65.026 ns |  1.72 |         - | 
| WaitAndSignal · AsyncCountdownEv · ProtoPromise | 10               | 436.714 ns | 11.57 |     205 B |