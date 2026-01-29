| Description                                                | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|----------------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (Managed)      | 128B         |     611.9 ns |    11.72 ns |    11.51 ns |     112 B |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (BouncyCastle) | 128B         |     791.6 ns |     3.62 ns |     3.39 ns |     112 B |
|                                                            |              |              |             |             |           |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (Managed)      | 137B         |     635.2 ns |     2.69 ns |     2.10 ns |     112 B |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (BouncyCastle) | 137B         |     827.8 ns |     3.30 ns |     3.09 ns |     112 B |
|                                                            |              |              |             |             |           |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (Managed)      | 1KB          |   3,786.7 ns |    33.03 ns |    29.28 ns |     112 B |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (BouncyCastle) | 1KB          |   4,968.9 ns |    23.76 ns |    22.23 ns |     112 B |
|                                                            |              |              |             |             |           |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (Managed)      | 1025B        |   3,806.2 ns |    43.98 ns |    38.99 ns |     112 B |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (BouncyCastle) | 1025B        |   4,982.4 ns |    31.94 ns |    28.31 ns |     112 B |
|                                                            |              |              |             |             |           |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (Managed)      | 8KB          |  29,148.2 ns |   209.47 ns |   195.93 ns |     112 B |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (BouncyCastle) | 8KB          |  38,447.7 ns |   160.15 ns |   141.96 ns |     112 B |
|                                                            |              |              |             |             |           |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (Managed)      | 128KB        | 465,221.2 ns | 2,988.57 ns | 2,649.29 ns |     112 B |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (BouncyCastle) | 128KB        | 612,776.1 ns | 3,809.94 ns | 3,377.41 ns |     112 B |