| Description                                                | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|----------------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (Managed)      | 128B         |     613.4 ns |    11.58 ns |    10.83 ns |     112 B |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (BouncyCastle) | 128B         |     797.1 ns |     9.22 ns |     8.63 ns |     112 B |
|                                                            |              |              |             |             |           |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (Managed)      | 137B         |     634.5 ns |     3.42 ns |     3.03 ns |     112 B |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (BouncyCastle) | 137B         |     836.7 ns |     6.76 ns |     6.32 ns |     112 B |
|                                                            |              |              |             |             |           |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (Managed)      | 1KB          |   3,793.9 ns |    31.09 ns |    29.09 ns |     112 B |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (BouncyCastle) | 1KB          |   5,013.9 ns |    41.25 ns |    36.57 ns |     112 B |
|                                                            |              |              |             |             |           |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (Managed)      | 1025B        |   3,791.2 ns |    29.79 ns |    27.87 ns |     112 B |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (BouncyCastle) | 1025B        |   5,029.3 ns |    51.60 ns |    48.26 ns |     112 B |
|                                                            |              |              |             |             |           |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (Managed)      | 8KB          |  29,193.9 ns |   206.87 ns |   183.38 ns |     112 B |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (BouncyCastle) | 8KB          |  38,583.0 ns |   345.60 ns |   323.27 ns |     112 B |
|                                                            |              |              |             |             |           |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (Managed)      | 128KB        | 465,355.6 ns | 2,648.25 ns | 2,477.17 ns |     112 B |
| ComputeHash · Ascon-Hash256 · Ascon-Hash256 (BouncyCastle) | 128KB        | 614,417.0 ns | 4,675.66 ns | 4,373.61 ns |     112 B |