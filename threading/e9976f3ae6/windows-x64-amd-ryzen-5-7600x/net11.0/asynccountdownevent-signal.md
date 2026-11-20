| Description                                          | ParticipantCount | Mean          | Error       | StdDev      | Ratio    | Allocated | 
|----------------------------------------------------- |----------------- |--------------:|------------:|------------:|---------:|----------:|
| SignalAndWait · AsyncCountdownEvent · CountdownEvent | 1                |      5.369 ns |   0.0141 ns |   0.0118 ns |     0.78 |         - | 
| SignalAndWait · AsyncCountdownEvent · ProtoPromise   | 1                |      5.834 ns |   0.0262 ns |   0.0219 ns |     0.84 |         - | 
| SignalAndWait · AsyncCountdownEvent · Pooled         | 1                |      6.919 ns |   0.0270 ns |   0.0240 ns |     1.00 |         - | 
| SignalAndWait · AsyncCountdownEvent · RefImpl        | 1                |     16.487 ns |   0.0319 ns |   0.0266 ns |     2.38 |      96 B | 
| WaitAndSignal · AsyncCountdownEvent · ProtoPromise   | 1                |     19.537 ns |   0.0573 ns |   0.0478 ns |     2.82 |         - | 
| WaitAndSignal · AsyncCountdownEvent · Pooled         | 1                |     51.045 ns |   0.3373 ns |   0.3155 ns |     7.38 |         - | 
| SignalAndWait · AsyncCountdownEvent · DotNext        | 1                | 18,125.524 ns | 117.3776 ns | 109.7951 ns | 2,619.76 |   26597 B | 
|                                                      |                  |               |             |             |          |           | 
| SignalAndWait · AsyncCountdownEvent · ProtoPromise   | 10               |     19.886 ns |   0.0320 ns |   0.0300 ns |     0.80 |         - | 
| SignalAndWait · AsyncCountdownEvent · CountdownEvent | 10               |     22.178 ns |   0.0217 ns |   0.0182 ns |     0.90 |         - | 
| SignalAndWait · AsyncCountdownEvent · Pooled         | 10               |     24.719 ns |   0.1121 ns |   0.0936 ns |     1.00 |         - | 
| WaitAndSignal · AsyncCountdownEvent · ProtoPromise   | 10               |     30.681 ns |   0.0593 ns |   0.0526 ns |     1.24 |         - | 
| SignalAndWait · AsyncCountdownEvent · RefImpl        | 10               |     32.545 ns |   0.0953 ns |   0.0796 ns |     1.32 |      96 B | 
| WaitAndSignal · AsyncCountdownEvent · Pooled         | 10               |     66.741 ns |   0.1997 ns |   0.1771 ns |     2.70 |         - | 
| SignalAndWait · AsyncCountdownEvent · DotNext        | 10               | 18,257.335 ns | 125.2658 ns | 117.1737 ns |   738.59 |   26597 B |