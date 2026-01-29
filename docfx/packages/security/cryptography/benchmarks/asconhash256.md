| Description                                                | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|----------------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (Managed)      | 128B         |     610.6 ns |    11.98 ns |    12.82 ns |     112 B |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (BouncyCastle) | 128B         |     792.7 ns |     3.56 ns |     2.98 ns |     112 B |
|                                                            |              |              |             |             |           |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (Managed)      | 137B         |     631.0 ns |     4.85 ns |     4.53 ns |     112 B |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (BouncyCastle) | 137B         |     835.0 ns |     2.87 ns |     2.68 ns |     112 B |
|                                                            |              |              |             |             |           |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (Managed)      | 1KB          |   3,771.8 ns |    41.08 ns |    38.42 ns |     112 B |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (BouncyCastle) | 1KB          |   4,962.1 ns |    12.83 ns |    12.01 ns |     112 B |
|                                                            |              |              |             |             |           |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (Managed)      | 1025B        |   3,759.0 ns |    24.47 ns |    21.69 ns |     112 B |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (BouncyCastle) | 1025B        |   5,027.2 ns |    55.49 ns |    46.33 ns |     112 B |
|                                                            |              |              |             |             |           |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (Managed)      | 8KB          |  29,233.9 ns |   211.82 ns |   198.14 ns |     112 B |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (BouncyCastle) | 8KB          |  38,517.5 ns |   191.96 ns |   179.56 ns |     112 B |
|                                                            |              |              |             |             |           |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (Managed)      | 128KB        | 462,380.3 ns | 2,473.80 ns | 2,313.99 ns |     112 B |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (BouncyCastle) | 128KB        | 612,417.1 ns | 4,308.91 ns | 3,819.74 ns |     112 B |