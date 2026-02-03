| Description                                           | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (Managed) | 128B         |     186.2 ns |     0.95 ns |     0.89 ns |     176 B |
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (AVX2)    | 128B         |     212.9 ns |     0.58 ns |     0.52 ns |     176 B |
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (AVX512F) | 128B         |     219.5 ns |     0.91 ns |     0.81 ns |     176 B |
|                                                       |              |              |             |             |           |
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (Managed) | 137B         |     341.5 ns |     1.15 ns |     0.96 ns |     176 B |
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (AVX2)    | 137B         |     388.4 ns |     1.29 ns |     1.15 ns |     176 B |
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (AVX512F) | 137B         |     404.2 ns |     1.55 ns |     1.45 ns |     176 B |
|                                                       |              |              |             |             |           |
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (Managed) | 1KB          |     950.0 ns |     2.67 ns |     2.50 ns |     176 B |
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (AVX2)    | 1KB          |   1,227.6 ns |     5.85 ns |     4.89 ns |     176 B |
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (AVX512F) | 1KB          |   1,287.9 ns |     2.73 ns |     2.42 ns |     176 B |
|                                                       |              |              |             |             |           |
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (Managed) | 1025B        |     953.4 ns |    10.78 ns |    10.08 ns |     176 B |
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (AVX2)    | 1025B        |   1,226.1 ns |     3.12 ns |     2.76 ns |     176 B |
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (AVX512F) | 1025B        |   1,291.8 ns |     5.78 ns |     4.51 ns |     176 B |
|                                                       |              |              |             |             |           |
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (Managed) | 8KB          |   6,587.4 ns |    30.05 ns |    28.11 ns |     176 B |
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (AVX2)    | 8KB          |   8,668.8 ns |    36.64 ns |    30.59 ns |     176 B |
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (AVX512F) | 8KB          |   9,144.7 ns |    42.07 ns |    37.30 ns |     176 B |
|                                                       |              |              |             |             |           |
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (Managed) | 128KB        | 102,764.1 ns |   535.00 ns |   500.44 ns |     176 B |
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (AVX2)    | 128KB        | 135,971.3 ns |   761.27 ns |   674.85 ns |     176 B |
| ComputeHash · TurboSHAKE256 · TurboSHAKE256 (AVX512F) | 128KB        | 143,500.5 ns | 2,029.45 ns | 1,799.05 ns |     176 B |