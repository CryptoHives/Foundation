| Description                                     | ParticipantCount | Mean      | Ratio | Allocated | 
|------------------------------------------------ |----------------- |----------:|------:|----------:|
| SignalAndWait · CountdownEvent · System         | 1                |  6.661 ns |  0.83 |         - | 
| SignalAndWait · AsyncCountdownEv · ProtoPromise | 1                |  7.370 ns |  0.92 |         - | 
| SignalAndWait · AsyncCountdownEv · Pooled       | 1                |  8.016 ns |  1.00 |         - | 
| SignalAndWait · AsyncCountdownEv · RefImpl      | 1                | 15.803 ns |  1.97 |      96 B | 
| WaitAndSignal · AsyncCountdownEv · ProtoPromise | 1                | 18.378 ns |  2.29 |         - | 
| WaitAndSignal · AsyncCountdownEv · Pooled       | 1                | 43.926 ns |  5.48 |         - | 
|                                                 |                  |           |       |           | 
| SignalAndWait · AsyncCountdownEv · ProtoPromise | 10               | 17.067 ns |  0.77 |         - | 
| SignalAndWait · CountdownEvent · System         | 10               | 20.834 ns |  0.94 |         - | 
| SignalAndWait · AsyncCountdownEv · Pooled       | 10               | 22.233 ns |  1.00 |         - | 
| WaitAndSignal · AsyncCountdownEv · ProtoPromise | 10               | 28.077 ns |  1.26 |         - | 
| SignalAndWait · AsyncCountdownEv · RefImpl      | 10               | 28.195 ns |  1.27 |      96 B | 
| WaitAndSignal · AsyncCountdownEv · Pooled       | 10               | 57.694 ns |  2.60 |         - |