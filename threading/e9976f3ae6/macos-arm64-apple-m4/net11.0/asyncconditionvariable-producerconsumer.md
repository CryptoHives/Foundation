| Description                                                | Iterations | Mean       | Error    | StdDev   | Ratio | Allocated | 
|----------------------------------------------------------- |----------- |-----------:|---------:|---------:|------:|----------:|
| ProducerConsumer · AsyncConditionVariable · Pooled         | 1          |   407.5 ns |  6.28 ns |  5.88 ns |  0.80 |     293 B | 
| ProducerConsumer · AsyncConditionVariable · RefImpl        | 1          |   510.9 ns | 10.14 ns | 12.83 ns |  1.00 |     306 B | 
| ProducerConsumer · AsyncConditionVariable · Pooled (timed) | 1          |   530.5 ns | 16.63 ns | 49.04 ns |  1.04 |     311 B | 
| ProducerConsumer · AsyncConditionVariable · Nito.AsyncEx   | 1          |   551.7 ns | 10.85 ns | 15.91 ns |  1.08 |     925 B | 
|                                                            |            |            |          |          |       |           | 
| ProducerConsumer · AsyncConditionVariable · Pooled         | 10         |   516.1 ns |  9.78 ns | 11.64 ns |  0.39 |     299 B | 
| ProducerConsumer · AsyncConditionVariable · Pooled (timed) | 10         |   525.1 ns | 10.17 ns | 12.11 ns |  0.40 |     306 B | 
| ProducerConsumer · AsyncConditionVariable · RefImpl        | 10         | 1,308.6 ns | 25.07 ns | 24.62 ns |  1.00 |     557 B | 
| ProducerConsumer · AsyncConditionVariable · Nito.AsyncEx   | 10         | 2,635.5 ns | 50.84 ns | 62.44 ns |  2.01 |    4283 B |