| Description                                           | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (Managed) | 128B         |     385.5 ns |     1.08 ns |     0.90 ns |     176 B |
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (AVX2)    | 128B         |     414.5 ns |     1.44 ns |     1.20 ns |     176 B |
|                                                       |              |              |             |             |           |
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (Managed) | 137B         |     778.8 ns |     3.11 ns |     2.91 ns |     176 B |
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (AVX2)    | 137B         |     852.0 ns |     3.22 ns |     3.01 ns |     176 B |
|                                                       |              |              |             |             |           |
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (Managed) | 1KB          |   1,878.0 ns |     6.65 ns |     6.22 ns |     176 B |
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (AVX2)    | 1KB          |   2,179.1 ns |     8.01 ns |     7.10 ns |     176 B |
|                                                       |              |              |             |             |           |
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (Managed) | 1025B        |   1,871.6 ns |     5.30 ns |     4.70 ns |     176 B |
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (AVX2)    | 1025B        |   2,175.6 ns |     9.74 ns |     8.63 ns |     176 B |
|                                                       |              |              |             |             |           |
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (Managed) | 8KB          |  11,763.5 ns |    47.62 ns |    44.54 ns |     176 B |
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (AVX2)    | 8KB          |  14,853.1 ns |    50.53 ns |    47.27 ns |     176 B |
|                                                       |              |              |             |             |           |
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (Managed) | 128KB        | 182,755.0 ns | 3,616.59 ns | 3,020.02 ns |     176 B |
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (AVX2)    | 128KB        | 229,664.4 ns |   796.17 ns |   664.84 ns |     176 B |