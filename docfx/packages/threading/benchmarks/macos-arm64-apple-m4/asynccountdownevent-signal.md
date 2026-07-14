| Description                                     | ParticipantCount | Mean      | Ratio | Allocated | 
|------------------------------------------------ |----------------- |----------:|------:|----------:|
| SignalAndWait · AsyncCountdownEv · ProtoPromise | 1                |  4.281 ns |  0.77 |         - | 
| SignalAndWait · AsyncCountdownEv · Pooled       | 1                |  5.573 ns |  1.00 |         - | 
| SignalAndWait · CountdownEvent · System         | 1                |  6.662 ns |  1.20 |         - | 
| SignalAndWait · AsyncCountdownEv · RefImpl      | 1                | 13.377 ns |  2.40 |      96 B | 
| WaitAndSignal · AsyncCountdownEv · ProtoPromise | 1                | 13.752 ns |  2.47 |         - | 
| WaitAndSignal · AsyncCountdownEv · Pooled       | 1                | 35.327 ns |  6.34 |         - | 
|                                                 |                  |           |       |           | 
| SignalAndWait · AsyncCountdownEv · ProtoPromise | 10               | 15.227 ns |  0.70 |         - | 
| SignalAndWait · CountdownEvent · System         | 10               | 16.373 ns |  0.75 |         - | 
| SignalAndWait · AsyncCountdownEv · RefImpl      | 10               | 20.918 ns |  0.96 |      96 B | 
| SignalAndWait · AsyncCountdownEv · Pooled       | 10               | 21.765 ns |  1.00 |         - | 
| WaitAndSignal · AsyncCountdownEv · ProtoPromise | 10               | 22.452 ns |  1.03 |         - | 
| WaitAndSignal · AsyncCountdownEv · Pooled       | 10               | 46.098 ns |  2.12 |         - |