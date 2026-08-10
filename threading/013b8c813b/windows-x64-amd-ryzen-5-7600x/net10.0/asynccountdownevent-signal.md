| Description                                     | ParticipantCount | Mean      | Ratio | Allocated | 
|------------------------------------------------ |----------------- |----------:|------:|----------:|
| SignalAndWait · CountdownEvent · System         | 1                |  6.767 ns |  0.89 |         - | 
| SignalAndWait · AsyncCountdownEv · Pooled       | 1                |  7.574 ns |  1.00 |         - | 
| SignalAndWait · AsyncCountdownEv · ProtoPromise | 1                |  7.588 ns |  1.00 |         - | 
| SignalAndWait · AsyncCountdownEv · RefImpl      | 1                | 16.461 ns |  2.17 |      96 B | 
| WaitAndSignal · AsyncCountdownEv · ProtoPromise | 1                | 18.802 ns |  2.48 |         - | 
| WaitAndSignal · AsyncCountdownEv · Pooled       | 1                | 49.150 ns |  6.49 |         - | 
|                                                 |                  |           |       |           | 
| SignalAndWait · AsyncCountdownEv · ProtoPromise | 10               | 17.544 ns |  0.76 |         - | 
| SignalAndWait · CountdownEvent · System         | 10               | 20.060 ns |  0.87 |         - | 
| SignalAndWait · AsyncCountdownEv · Pooled       | 10               | 23.027 ns |  1.00 |         - | 
| SignalAndWait · AsyncCountdownEv · RefImpl      | 10               | 28.830 ns |  1.25 |      96 B | 
| WaitAndSignal · AsyncCountdownEv · ProtoPromise | 10               | 29.128 ns |  1.26 |         - | 
| WaitAndSignal · AsyncCountdownEv · Pooled       | 10               | 64.808 ns |  2.81 |         - |