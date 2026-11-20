| Description                                                | Iterations | Mean       | Error    | StdDev   | Ratio | Allocated | 
|----------------------------------------------------------- |----------- |-----------:|---------:|---------:|------:|----------:|
| ProducerConsumer · AsyncConditionVariable · Pooled         | 1          |   526.9 ns |  7.51 ns | 13.15 ns |  0.82 |     288 B | 
| ProducerConsumer · AsyncConditionVariable · Pooled (timed) | 1          |   559.6 ns |  5.75 ns | 10.93 ns |  0.87 |     299 B | 
| ProducerConsumer · AsyncConditionVariable · RefImpl        | 1          |   645.2 ns |  9.17 ns | 16.76 ns |  1.00 |     288 B | 
| ProducerConsumer · AsyncConditionVariable · Nito.AsyncEx   | 1          |   997.9 ns |  4.19 ns |  7.55 ns |  1.55 |     923 B | 
|                                                            |            |            |          |          |       |           | 
| ProducerConsumer · AsyncConditionVariable · Pooled         | 10         |   932.1 ns |  9.04 ns | 16.07 ns |  0.43 |     289 B | 
| ProducerConsumer · AsyncConditionVariable · Pooled (timed) | 10         |   944.3 ns |  1.60 ns |  2.89 ns |  0.43 |     293 B | 
| ProducerConsumer · AsyncConditionVariable · RefImpl        | 10         | 2,190.3 ns | 18.46 ns | 32.33 ns |  1.00 |     825 B | 
| ProducerConsumer · AsyncConditionVariable · Nito.AsyncEx   | 10         | 5,974.7 ns | 45.66 ns | 83.50 ns |  2.73 |    5385 B |