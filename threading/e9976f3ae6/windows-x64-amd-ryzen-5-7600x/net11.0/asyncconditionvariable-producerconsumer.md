| Description                                                | Iterations | Mean       | Error    | StdDev   | Ratio | Allocated | 
|----------------------------------------------------------- |----------- |-----------:|---------:|---------:|------:|----------:|
| ProducerConsumer · AsyncConditionVariable · Pooled         | 1          |   223.9 ns |  0.54 ns |  0.42 ns |  0.65 |     288 B | 
| ProducerConsumer · AsyncConditionVariable · Pooled (timed) | 1          |   231.3 ns |  1.74 ns |  1.62 ns |  0.67 |     293 B | 
| ProducerConsumer · AsyncConditionVariable · RefImpl        | 1          |   343.3 ns |  1.12 ns |  1.05 ns |  1.00 |     289 B | 
| ProducerConsumer · AsyncConditionVariable · Nito.AsyncEx   | 1          |   467.1 ns |  3.81 ns |  3.38 ns |  1.36 |     919 B | 
|                                                            |            |            |          |          |       |           | 
| ProducerConsumer · AsyncConditionVariable · Pooled         | 10         |   384.2 ns |  0.46 ns |  0.38 ns |  0.42 |     292 B | 
| ProducerConsumer · AsyncConditionVariable · Pooled (timed) | 10         |   387.9 ns |  2.05 ns |  1.81 ns |  0.43 |     292 B | 
| ProducerConsumer · AsyncConditionVariable · RefImpl        | 10         |   911.3 ns |  4.59 ns |  4.07 ns |  1.00 |     630 B | 
| ProducerConsumer · AsyncConditionVariable · Nito.AsyncEx   | 10         | 2,576.5 ns | 19.14 ns | 15.99 ns |  2.83 |    5217 B |