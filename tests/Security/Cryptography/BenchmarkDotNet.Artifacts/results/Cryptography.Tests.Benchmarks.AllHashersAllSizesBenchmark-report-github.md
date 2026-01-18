```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26100.4770/24H2/2024Update/HudsonValley)
AMD Ryzen 5 7600X 4.70GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 10.0.102
  [Host]    : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v4
  .NET 10.0 : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v4

Method=ComputeHash  Job=.NET 10.0  Runtime=.NET 10.0  
Toolchain=net10.0  

```
| Description                                                 | TestDataSize | Mean           | Error        | StdDev       | Allocated |
|------------------------------------------------------------ |------------- |---------------:|-------------:|-------------:|----------:|
| **ComputeHash | BLAKE2b-512 | BouncyCastle**                    | **128B**         |       **129.6 ns** |      **0.83 ns** |      **0.77 ns** |     **176 B** |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Avx2            | 128B         |       145.3 ns |      2.90 ns |      2.98 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Scalar          | 128B         |       394.1 ns |      1.36 ns |      1.14 ns |     176 B |
|                                                             |              |                |              |              |           |
| ComputeHash | BLAKE2b-512 | BouncyCastle                    | 137B         |       208.2 ns |      0.65 ns |      0.51 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Avx2            | 137B         |       244.6 ns |      1.79 ns |      1.59 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Scalar          | 137B         |       749.4 ns |      5.25 ns |      4.91 ns |     176 B |
|                                                             |              |                |              |              |           |
| ComputeHash | BLAKE2b-512 | BouncyCastle                    | 1KB          |       749.8 ns |      6.85 ns |      6.07 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Avx2            | 1KB          |       893.1 ns |     16.98 ns |     16.68 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Scalar          | 1KB          |     2,872.7 ns |     18.52 ns |     17.33 ns |     176 B |
|                                                             |              |                |              |              |           |
| ComputeHash | BLAKE2b-512 | BouncyCastle                    | 1025B        |       840.4 ns |     12.95 ns |     12.71 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Avx2            | 1025B        |     1,008.0 ns |     19.01 ns |     19.53 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Scalar          | 1025B        |     3,235.3 ns |     31.07 ns |     25.95 ns |     176 B |
|                                                             |              |                |              |              |           |
| ComputeHash | BLAKE2b-512 | BouncyCastle                    | 8KB          |     5,650.5 ns |     42.59 ns |     39.84 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Avx2            | 8KB          |     7,084.6 ns |     75.00 ns |     70.16 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Scalar          | 8KB          |    22,932.9 ns |    154.79 ns |    144.79 ns |     176 B |
|                                                             |              |                |              |              |           |
| ComputeHash | BLAKE2b-512 | BouncyCastle                    | 128KB        |    89,292.4 ns |    657.91 ns |    615.41 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Avx2            | 128KB        |   111,991.1 ns |    726.76 ns |    644.26 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Scalar          | 128KB        |   363,571.2 ns |  2,474.34 ns |  2,314.50 ns |     176 B |
|                                                             |              |                |              |              |           |
| ComputeHash | BLAKE2s-256 | BouncyCastle                    | 128B         |       187.3 ns |      0.44 ns |      0.39 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Avx2            | 128B         |       192.9 ns |      1.27 ns |      1.19 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Sse2            | 128B         |       212.2 ns |      1.43 ns |      1.27 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Scalar          | 128B         |       625.5 ns |      5.06 ns |      4.73 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | BLAKE2s-256 | BouncyCastle                    | 137B         |       264.5 ns |      1.83 ns |      1.71 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Avx2            | 137B         |       270.3 ns |      1.92 ns |      1.70 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Sse2            | 137B         |       304.7 ns |      1.75 ns |      1.64 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Scalar          | 137B         |       922.7 ns |      2.88 ns |      2.56 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Avx2            | 1KB          |     1,253.7 ns |      8.40 ns |      7.45 ns |     112 B |
| ComputeHash | BLAKE2s-256 | BouncyCastle                    | 1KB          |     1,266.0 ns |     10.13 ns |      8.98 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Sse2            | 1KB          |     1,429.4 ns |      7.74 ns |      6.86 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Scalar          | 1KB          |     4,708.4 ns |     20.16 ns |     16.84 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | BLAKE2s-256 | BouncyCastle                    | 1025B        |     1,337.8 ns |      7.44 ns |      6.96 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Avx2            | 1025B        |     1,337.8 ns |      8.01 ns |      7.50 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Sse2            | 1025B        |     1,525.8 ns |      8.98 ns |      7.96 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Scalar          | 1025B        |     5,012.2 ns |     38.26 ns |     33.92 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | BLAKE2s-256 | BouncyCastle                    | 8KB          |     9,753.7 ns |     53.57 ns |     50.11 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Avx2            | 8KB          |     9,754.3 ns |     81.12 ns |     75.88 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Sse2            | 8KB          |    11,161.6 ns |     75.21 ns |     70.35 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Scalar          | 8KB          |    37,332.2 ns |    188.70 ns |    167.28 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | BLAKE2s-256 | BouncyCastle                    | 128KB        |   155,211.0 ns |  1,863.84 ns |  1,652.25 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Avx2            | 128KB        |   155,245.0 ns |    710.12 ns |    592.99 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Sse2            | 128KB        |   177,915.9 ns |    759.39 ns |    710.33 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Scalar          | 128KB        |   598,413.4 ns |  3,913.91 ns |  3,469.58 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | BLAKE3 | Native                               | 128B         |       116.0 ns |      0.31 ns |      0.28 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Ssse3                 | 128B         |       386.8 ns |      2.79 ns |      2.61 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Scalar                | 128B         |       581.4 ns |      5.44 ns |      5.09 ns |     112 B |
| ComputeHash | BLAKE3 | BouncyCastle                         | 128B         |     1,266.2 ns |      8.30 ns |      7.76 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | BLAKE3 | Native                               | 137B         |       160.8 ns |      0.78 ns |      0.73 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Ssse3                 | 137B         |       447.9 ns |      1.47 ns |      1.23 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Scalar                | 137B         |       838.4 ns |      4.50 ns |      4.21 ns |     112 B |
| ComputeHash | BLAKE3 | BouncyCastle                         | 137B         |     1,871.6 ns |     11.10 ns |     10.39 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | BLAKE3 | Native                               | 1KB          |       766.8 ns |      4.02 ns |      3.76 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Ssse3                 | 1KB          |     1,308.0 ns |      7.48 ns |      7.00 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Scalar                | 1KB          |     4,250.6 ns |     27.43 ns |     25.66 ns |     112 B |
| ComputeHash | BLAKE3 | BouncyCastle                         | 1KB          |     9,332.3 ns |     79.63 ns |     74.48 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | BLAKE3 | Native                               | 1025B        |       869.2 ns |      2.97 ns |      2.64 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Ssse3                 | 1025B        |     1,454.2 ns |      9.83 ns |      9.19 ns |     224 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Scalar                | 1025B        |     4,801.9 ns |     24.46 ns |     22.88 ns |     224 B |
| ComputeHash | BLAKE3 | BouncyCastle                         | 1025B        |    10,852.9 ns |     67.23 ns |     62.88 ns |     168 B |
|                                                             |              |                |              |              |           |
| ComputeHash | BLAKE3 | Native                               | 8KB          |     1,191.5 ns |      4.72 ns |      4.41 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Ssse3                 | 8KB          |    10,388.8 ns |     45.72 ns |     42.77 ns |     896 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Scalar                | 8KB          |    35,887.9 ns |    336.89 ns |    315.13 ns |     896 B |
| ComputeHash | BLAKE3 | BouncyCastle                         | 8KB          |    79,849.9 ns |    755.66 ns |    706.84 ns |     504 B |
|                                                             |              |                |              |              |           |
| ComputeHash | BLAKE3 | Native                               | 128KB        |    14,444.8 ns |    107.49 ns |     89.76 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Ssse3                 | 128KB        |   169,902.6 ns |    829.33 ns |    775.75 ns |   14336 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Scalar                | 128KB        |   575,762.8 ns |  3,953.94 ns |  3,698.52 ns |   14336 B |
| ComputeHash | BLAKE3 | BouncyCastle                         | 128KB        | 1,275,693.9 ns |  6,009.52 ns |  5,327.29 ns |    7224 B |
|                                                             |              |                |              |              |           |
| ComputeHash | CSHAKE128 | CShake128_Managed_Scalar          | 128B         |       275.1 ns |      3.43 ns |      3.21 ns |     112 B |
| ComputeHash | CSHAKE128 | CShake128_Managed_Ssse3           | 128B         |       314.6 ns |      3.13 ns |      2.93 ns |     112 B |
| ComputeHash | CSHAKE128 | CShake128_Managed_Avx512F         | 128B         |       344.9 ns |      2.29 ns |      2.03 ns |     112 B |
| ComputeHash | CSHAKE128 | CShake128_Managed_Avx2            | 128B         |       355.7 ns |      1.46 ns |      1.37 ns |     112 B |
| ComputeHash | CSHAKE128 | BouncyCastle                      | 128B         |       361.7 ns |      1.70 ns |      1.51 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | CSHAKE128 | CShake128_Managed_Scalar          | 137B         |       270.6 ns |      2.54 ns |      2.38 ns |     112 B |
| ComputeHash | CSHAKE128 | CShake128_Managed_Ssse3           | 137B         |       310.1 ns |      2.83 ns |      2.65 ns |     112 B |
| ComputeHash | CSHAKE128 | CShake128_Managed_Avx512F         | 137B         |       340.6 ns |      3.07 ns |      2.72 ns |     112 B |
| ComputeHash | CSHAKE128 | CShake128_Managed_Avx2            | 137B         |       353.1 ns |      2.24 ns |      2.10 ns |     112 B |
| ComputeHash | CSHAKE128 | BouncyCastle                      | 137B         |       364.1 ns |      2.21 ns |      2.07 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | CSHAKE128 | CShake128_Managed_Scalar          | 1KB          |     1,572.0 ns |     31.05 ns |     35.76 ns |     112 B |
| ComputeHash | CSHAKE128 | CShake128_Managed_Ssse3           | 1KB          |     1,818.2 ns |     16.74 ns |     13.98 ns |     112 B |
| ComputeHash | CSHAKE128 | CShake128_Managed_Avx512F         | 1KB          |     2,012.7 ns |     14.86 ns |     13.90 ns |     112 B |
| ComputeHash | CSHAKE128 | CShake128_Managed_Avx2            | 1KB          |     2,235.4 ns |     17.73 ns |     15.72 ns |     112 B |
| ComputeHash | CSHAKE128 | BouncyCastle                      | 1KB          |     2,243.3 ns |     44.91 ns |     46.12 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | CSHAKE128 | CShake128_Managed_Scalar          | 1025B        |     1,530.5 ns |     20.80 ns |     17.37 ns |     112 B |
| ComputeHash | CSHAKE128 | CShake128_Managed_Ssse3           | 1025B        |     1,819.5 ns |     22.81 ns |     20.22 ns |     112 B |
| ComputeHash | CSHAKE128 | CShake128_Managed_Avx512F         | 1025B        |     2,027.1 ns |     38.42 ns |     41.11 ns |     112 B |
| ComputeHash | CSHAKE128 | CShake128_Managed_Avx2            | 1025B        |     2,240.2 ns |     38.67 ns |     36.18 ns |     112 B |
| ComputeHash | CSHAKE128 | BouncyCastle                      | 1025B        |     2,285.6 ns |     35.01 ns |     32.75 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | CSHAKE128 | CShake128_Managed_Scalar          | 8KB          |    10,336.3 ns |    198.86 ns |    251.50 ns |     112 B |
| ComputeHash | CSHAKE128 | CShake128_Managed_Ssse3           | 8KB          |    12,230.0 ns |    243.12 ns |    270.23 ns |     112 B |
| ComputeHash | CSHAKE128 | CShake128_Managed_Avx512F         | 8KB          |    13,529.9 ns |    259.75 ns |    255.11 ns |     112 B |
| ComputeHash | CSHAKE128 | CShake128_Managed_Avx2            | 8KB          |    15,019.9 ns |    249.78 ns |    221.42 ns |     112 B |
| ComputeHash | CSHAKE128 | BouncyCastle                      | 8KB          |    15,492.6 ns |    208.43 ns |    174.05 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | CSHAKE128 | CShake128_Managed_Scalar          | 128KB        |   158,780.7 ns |  2,344.79 ns |  2,078.59 ns |     112 B |
| ComputeHash | CSHAKE128 | CShake128_Managed_Ssse3           | 128KB        |   191,361.4 ns |  2,749.30 ns |  2,571.69 ns |     112 B |
| ComputeHash | CSHAKE128 | CShake128_Managed_Avx512F         | 128KB        |   212,816.6 ns |  3,198.04 ns |  2,834.98 ns |     112 B |
| ComputeHash | CSHAKE128 | CShake128_Managed_Avx2            | 128KB        |   234,879.2 ns |  1,254.20 ns |  1,173.18 ns |     112 B |
| ComputeHash | CSHAKE128 | BouncyCastle                      | 128KB        |   242,374.1 ns |  2,231.79 ns |  1,978.42 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | CSHAKE256 | CShake256_Managed_Scalar          | 128B         |       283.2 ns |      5.62 ns |      5.52 ns |     176 B |
| ComputeHash | CSHAKE256 | CShake256_Managed_Ssse3           | 128B         |       333.0 ns |      6.30 ns |      6.19 ns |     176 B |
| ComputeHash | CSHAKE256 | CShake256_Managed_Avx512F         | 128B         |       354.6 ns |      5.47 ns |      5.12 ns |     176 B |
| ComputeHash | CSHAKE256 | BouncyCastle                      | 128B         |       361.3 ns |      3.66 ns |      3.43 ns |     176 B |
| ComputeHash | CSHAKE256 | CShake256_Managed_Avx2            | 128B         |       369.9 ns |      6.27 ns |      5.87 ns |     176 B |
|                                                             |              |                |              |              |           |
| ComputeHash | CSHAKE256 | CShake256_Managed_Scalar          | 137B         |       539.8 ns |     10.51 ns |     10.79 ns |     176 B |
| ComputeHash | CSHAKE256 | CShake256_Managed_Ssse3           | 137B         |       622.4 ns |      8.97 ns |      8.39 ns |     176 B |
| ComputeHash | CSHAKE256 | CShake256_Managed_Avx512F         | 137B         |       670.0 ns |     10.05 ns |      9.40 ns |     176 B |
| ComputeHash | CSHAKE256 | BouncyCastle                      | 137B         |       675.4 ns |     11.85 ns |     11.09 ns |     176 B |
| ComputeHash | CSHAKE256 | CShake256_Managed_Avx2            | 137B         |       691.2 ns |      5.23 ns |      4.90 ns |     176 B |
|                                                             |              |                |              |              |           |
| ComputeHash | CSHAKE256 | CShake256_Managed_Scalar          | 1KB          |     1,710.1 ns |     33.53 ns |     34.43 ns |     176 B |
| ComputeHash | CSHAKE256 | CShake256_Managed_Ssse3           | 1KB          |     2,069.5 ns |     19.63 ns |     18.36 ns |     176 B |
| ComputeHash | CSHAKE256 | CShake256_Managed_Avx512F         | 1KB          |     2,259.0 ns |     28.60 ns |     26.75 ns |     176 B |
| ComputeHash | CSHAKE256 | CShake256_Managed_Avx2            | 1KB          |     2,492.7 ns |      7.97 ns |      7.07 ns |     176 B |
| ComputeHash | CSHAKE256 | BouncyCastle                      | 1KB          |     2,537.1 ns |     43.21 ns |     40.42 ns |     176 B |
|                                                             |              |                |              |              |           |
| ComputeHash | CSHAKE256 | CShake256_Managed_Scalar          | 1025B        |     1,712.3 ns |     29.42 ns |     27.52 ns |     176 B |
| ComputeHash | CSHAKE256 | CShake256_Managed_Ssse3           | 1025B        |     2,069.1 ns |     35.68 ns |     33.38 ns |     176 B |
| ComputeHash | CSHAKE256 | CShake256_Managed_Avx512F         | 1025B        |     2,277.1 ns |     37.82 ns |     35.37 ns |     176 B |
| ComputeHash | CSHAKE256 | CShake256_Managed_Avx2            | 1025B        |     2,508.9 ns |     33.88 ns |     30.03 ns |     176 B |
| ComputeHash | CSHAKE256 | BouncyCastle                      | 1025B        |     2,534.7 ns |     40.10 ns |     37.51 ns |     176 B |
|                                                             |              |                |              |              |           |
| ComputeHash | CSHAKE256 | CShake256_Managed_Scalar          | 8KB          |    12,408.8 ns |    170.66 ns |    159.64 ns |     176 B |
| ComputeHash | CSHAKE256 | CShake256_Managed_Ssse3           | 8KB          |    15,037.7 ns |    230.47 ns |    204.30 ns |     176 B |
| ComputeHash | CSHAKE256 | CShake256_Managed_Avx512F         | 8KB          |    16,307.9 ns |     88.37 ns |     68.99 ns |     176 B |
| ComputeHash | CSHAKE256 | CShake256_Managed_Avx2            | 8KB          |    18,573.7 ns |    336.82 ns |    315.06 ns |     176 B |
| ComputeHash | CSHAKE256 | BouncyCastle                      | 8KB          |    18,827.5 ns |    179.31 ns |    167.73 ns |     176 B |
|                                                             |              |                |              |              |           |
| ComputeHash | CSHAKE256 | CShake256_Managed_Scalar          | 128KB        |   194,367.2 ns |  2,560.46 ns |  2,395.05 ns |     176 B |
| ComputeHash | CSHAKE256 | CShake256_Managed_Ssse3           | 128KB        |   235,162.8 ns |  3,729.09 ns |  3,488.19 ns |     176 B |
| ComputeHash | CSHAKE256 | CShake256_Managed_Avx512F         | 128KB        |   259,259.9 ns |  3,723.46 ns |  3,482.93 ns |     176 B |
| ComputeHash | CSHAKE256 | CShake256_Managed_Avx2            | 128KB        |   295,089.2 ns |  5,531.53 ns |  5,432.70 ns |     176 B |
| ComputeHash | CSHAKE256 | BouncyCastle                      | 128KB        |   296,948.3 ns |  2,788.22 ns |  2,608.10 ns |     176 B |
|                                                             |              |                |              |              |           |
| ComputeHash | Keccak-256 | Keccak256_Managed_Scalar         | 128B         |       241.7 ns |      4.84 ns |      5.18 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Ssse3          | 128B         |       284.3 ns |      5.19 ns |      4.60 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx512F        | 128B         |       317.7 ns |      5.84 ns |      5.46 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx2           | 128B         |       343.4 ns |      5.64 ns |      5.27 ns |     112 B |
| ComputeHash | Keccak-256 | BouncyCastle                     | 128B         |       364.9 ns |      6.40 ns |      5.68 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | Keccak-256 | Keccak256_Managed_Scalar         | 137B         |       494.4 ns |      9.90 ns |     10.16 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Ssse3          | 137B         |       576.5 ns |      7.39 ns |      6.91 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx512F        | 137B         |       633.5 ns |     10.54 ns |      9.86 ns |     112 B |
| ComputeHash | Keccak-256 | BouncyCastle                     | 137B         |       661.1 ns |     10.11 ns |      9.46 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx2           | 137B         |       692.0 ns |      8.85 ns |      8.28 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | Keccak-256 | Keccak256_Managed_Scalar         | 1KB          |     1,693.8 ns |     31.75 ns |     29.70 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Ssse3          | 1KB          |     2,008.6 ns |     25.99 ns |     24.31 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx512F        | 1KB          |     2,224.6 ns |     42.80 ns |     40.03 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx2           | 1KB          |     2,480.5 ns |     40.52 ns |     37.90 ns |     112 B |
| ComputeHash | Keccak-256 | BouncyCastle                     | 1KB          |     2,534.1 ns |     41.63 ns |     38.94 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | Keccak-256 | Keccak256_Managed_Scalar         | 1025B        |     1,778.4 ns |     29.74 ns |     27.81 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Ssse3          | 1025B        |     2,017.7 ns |     32.59 ns |     30.48 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx512F        | 1025B        |     2,235.2 ns |     42.47 ns |     41.71 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx2           | 1025B        |     2,480.7 ns |     42.86 ns |     40.10 ns |     112 B |
| ComputeHash | Keccak-256 | BouncyCastle                     | 1025B        |     2,516.5 ns |     39.42 ns |     36.87 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | Keccak-256 | Keccak256_Managed_Scalar         | 8KB          |    12,352.2 ns |    188.02 ns |    175.87 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Ssse3          | 8KB          |    14,918.4 ns |    199.90 ns |    186.99 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx512F        | 8KB          |    16,436.4 ns |    244.03 ns |    228.26 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx2           | 8KB          |    18,305.4 ns |     84.21 ns |     65.74 ns |     112 B |
| ComputeHash | Keccak-256 | BouncyCastle                     | 8KB          |    18,710.1 ns |    172.20 ns |    161.08 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | Keccak-256 | Keccak256_Managed_Scalar         | 128KB        |   192,607.5 ns |  1,064.17 ns |    995.43 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Ssse3          | 128KB        |   231,530.2 ns |    891.60 ns |    790.38 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx512F        | 128KB        |   255,841.4 ns |    426.69 ns |    378.25 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx2           | 128KB        |   287,517.0 ns |    922.45 ns |    862.86 ns |     112 B |
| ComputeHash | Keccak-256 | BouncyCastle                     | 128KB        |   294,186.4 ns |  1,305.25 ns |  1,220.93 ns |     112 B |
|                                                             |              |                |              |              |           |
| **ComputeHash | KMAC-128 | CryptoHives**                        | **128B**         |       **728.5 ns** |      **3.02 ns** |      **2.68 ns** |     **824 B** |
| **ComputeHash | KMAC-128 | OS Native**                          | **128B**         |     **1,068.9 ns** |      **6.36 ns** |      **5.31 ns** |     **296 B** |
| ComputeHash | KMAC-128 | BouncyCastle                       | 128B         |     2,004.9 ns |      8.55 ns |      7.58 ns |     400 B |
|                                                             |              |                |              |              |           |
| **ComputeHash | KMAC-128 | CryptoHives**                        | **137B**         |       **728.7 ns** |      **6.45 ns** |      **5.71 ns** |     **824 B** |
| **ComputeHash | KMAC-128 | OS Native**                          | **137B**         |     **1,083.6 ns** |      **5.53 ns** |      **4.90 ns** |     **312 B** |
| ComputeHash | KMAC-128 | BouncyCastle                       | 137B         |     2,015.8 ns |      8.81 ns |      7.81 ns |     400 B |
|                                                             |              |                |              |              |           |
| **ComputeHash | KMAC-128 | CryptoHives**                        | **1KB**          |     **1,993.3 ns** |     **16.32 ns** |     **15.26 ns** |     **824 B** |
| **ComputeHash | KMAC-128 | OS Native**                          | **1KB**          |     **2,541.3 ns** |     **18.17 ns** |     **17.00 ns** |    **1192 B** |
| ComputeHash | KMAC-128 | BouncyCastle                       | 1KB          |     3,860.3 ns |     17.15 ns |     15.21 ns |     400 B |
|                                                             |              |                |              |              |           |
| **ComputeHash | KMAC-128 | CryptoHives**                        | **1025B**        |     **1,988.0 ns** |     **11.13 ns** |     **10.41 ns** |     **824 B** |
| **ComputeHash | KMAC-128 | OS Native**                          | **1025B**        |     **2,553.0 ns** |     **18.49 ns** |     **16.40 ns** |    **1200 B** |
| ComputeHash | KMAC-128 | BouncyCastle                       | 1025B        |     3,858.1 ns |     15.68 ns |     13.90 ns |     400 B |
|                                                             |              |                |              |              |           |
| **ComputeHash | KMAC-128 | CryptoHives**                        | **8KB**          |    **10,426.4 ns** |     **76.04 ns** |     **71.13 ns** |     **824 B** |
| **ComputeHash | KMAC-128 | OS Native**                          | **8KB**          |    **12,954.5 ns** |     **63.52 ns** |     **53.04 ns** |    **8360 B** |
| ComputeHash | KMAC-128 | BouncyCastle                       | 8KB          |    16,760.6 ns |     94.21 ns |     83.51 ns |     400 B |
|                                                             |              |                |              |              |           |
| **ComputeHash | KMAC-128 | CryptoHives**                        | **128KB**        |   **157,693.3 ns** |    **731.73 ns** |    **611.02 ns** |     **824 B** |
| **ComputeHash | KMAC-128 | OS Native**                          | **128KB**        |   **224,230.0 ns** |    **877.86 ns** |    **733.06 ns** |  **131263 B** |
| ComputeHash | KMAC-128 | BouncyCastle                       | 128KB        |   241,550.9 ns |  1,153.26 ns |    963.02 ns |     400 B |
|                                                             |              |                |              |              |           |
| **ComputeHash | KMAC-256 | CryptoHives**                        | **128B**         |       **735.4 ns** |      **4.38 ns** |      **3.89 ns** |     **824 B** |
| **ComputeHash | KMAC-256 | OS Native**                          | **128B**         |     **1,073.5 ns** |      **5.25 ns** |      **4.66 ns** |     **360 B** |
| ComputeHash | KMAC-256 | BouncyCastle                       | 128B         |     1,985.1 ns |     10.39 ns |      8.67 ns |     464 B |
|                                                             |              |                |              |              |           |
| **ComputeHash | KMAC-256 | CryptoHives**                        | **137B**         |       **983.9 ns** |     **11.13 ns** |     **10.41 ns** |     **824 B** |
| **ComputeHash | KMAC-256 | OS Native**                          | **137B**         |     **1,304.9 ns** |      **6.88 ns** |      **6.10 ns** |     **376 B** |
| ComputeHash | KMAC-256 | BouncyCastle                       | 137B         |     2,280.4 ns |     12.63 ns |     10.55 ns |     464 B |
|                                                             |              |                |              |              |           |
| **ComputeHash | KMAC-256 | CryptoHives**                        | **1KB**          |     **2,153.5 ns** |     **11.49 ns** |     **10.75 ns** |     **824 B** |
| **ComputeHash | KMAC-256 | OS Native**                          | **1KB**          |     **2,756.6 ns** |     **11.80 ns** |      **9.85 ns** |    **1256 B** |
| ComputeHash | KMAC-256 | BouncyCastle                       | 1KB          |     4,133.3 ns |     32.05 ns |     28.41 ns |     464 B |
|                                                             |              |                |              |              |           |
| **ComputeHash | KMAC-256 | CryptoHives**                        | **1025B**        |     **2,149.8 ns** |     **22.06 ns** |     **19.56 ns** |     **824 B** |
| **ComputeHash | KMAC-256 | OS Native**                          | **1025B**        |     **2,759.3 ns** |     **16.08 ns** |     **14.25 ns** |    **1264 B** |
| ComputeHash | KMAC-256 | BouncyCastle                       | 1025B        |     4,122.5 ns |     16.37 ns |     13.67 ns |     464 B |
|                                                             |              |                |              |              |           |
| **ComputeHash | KMAC-256 | CryptoHives**                        | **8KB**          |    **12,766.4 ns** |     **73.78 ns** |     **69.01 ns** |     **824 B** |
| **ComputeHash | KMAC-256 | OS Native**                          | **8KB**          |    **15,677.9 ns** |    **153.77 ns** |    **136.31 ns** |    **8424 B** |
| ComputeHash | KMAC-256 | BouncyCastle                       | 8KB          |    20,245.1 ns |     90.77 ns |     80.46 ns |     464 B |
|                                                             |              |                |              |              |           |
| **ComputeHash | KMAC-256 | CryptoHives**                        | **128KB**        |   **192,858.1 ns** |    **659.11 ns** |    **616.53 ns** |     **824 B** |
| **ComputeHash | KMAC-256 | OS Native**                          | **128KB**        |   **265,314.5 ns** |  **3,518.58 ns** |  **2,938.17 ns** |  **131327 B** |
| ComputeHash | KMAC-256 | BouncyCastle                       | 128KB        |   295,596.0 ns |  1,117.35 ns |  1,045.17 ns |     464 B |
|                                                             |              |                |              |              |           |
| ComputeHash | KT128 | KT128_Managed_Scalar                  | 128B         |       230.7 ns |      1.68 ns |      1.58 ns |     584 B |
| ComputeHash | KT128 | KT128_Managed_Avx512F                 | 128B         |       261.9 ns |      0.98 ns |      0.92 ns |     584 B |
| ComputeHash | KT128 | KT128_Managed_Avx2                    | 128B         |       271.5 ns |      0.91 ns |      0.76 ns |     584 B |
| ComputeHash | KT128 | KT128_Managed_Ssse3                   | 128B         |       288.6 ns |      1.41 ns |      1.18 ns |     584 B |
|                                                             |              |                |              |              |           |
| ComputeHash | KT128 | KT128_Managed_Scalar                  | 137B         |       231.3 ns |      0.94 ns |      0.88 ns |     584 B |
| ComputeHash | KT128 | KT128_Managed_Ssse3                   | 137B         |       250.2 ns |      2.04 ns |      1.81 ns |     584 B |
| ComputeHash | KT128 | KT128_Managed_Avx512F                 | 137B         |       260.3 ns |      0.88 ns |      0.78 ns |     584 B |
| ComputeHash | KT128 | KT128_Managed_Avx2                    | 137B         |       270.5 ns |      1.30 ns |      1.09 ns |     584 B |
|                                                             |              |                |              |              |           |
| ComputeHash | KT128 | KT128_Managed_Scalar                  | 1KB          |       940.7 ns |      8.15 ns |      7.22 ns |     584 B |
| ComputeHash | KT128 | KT128_Managed_Ssse3                   | 1KB          |     1,081.2 ns |      5.46 ns |      4.84 ns |     584 B |
| ComputeHash | KT128 | KT128_Managed_Avx512F                 | 1KB          |     1,163.2 ns |      3.21 ns |      2.51 ns |     584 B |
| ComputeHash | KT128 | KT128_Managed_Avx2                    | 1KB          |     1,221.5 ns |      7.25 ns |      6.78 ns |     584 B |
|                                                             |              |                |              |              |           |
| ComputeHash | KT128 | KT128_Managed_Scalar                  | 1025B        |       940.6 ns |     14.54 ns |     12.89 ns |     584 B |
| ComputeHash | KT128 | KT128_Managed_Ssse3                   | 1025B        |     1,094.5 ns |     14.80 ns |     13.84 ns |     584 B |
| ComputeHash | KT128 | KT128_Managed_Avx512F                 | 1025B        |     1,193.8 ns |     22.82 ns |     28.02 ns |     584 B |
| ComputeHash | KT128 | KT128_Managed_Avx2                    | 1025B        |     1,268.2 ns |     24.39 ns |     31.72 ns |     584 B |
|                                                             |              |                |              |              |           |
| ComputeHash | KT128 | KT128_Managed_Scalar                  | 8KB          |     6,597.7 ns |    116.22 ns |    103.03 ns |    9328 B |
| ComputeHash | KT128 | KT128_Managed_Ssse3                   | 8KB          |     7,522.4 ns |     45.14 ns |     37.70 ns |    9328 B |
| ComputeHash | KT128 | KT128_Managed_Avx512F                 | 8KB          |     8,035.9 ns |    138.93 ns |    129.96 ns |    9328 B |
| ComputeHash | KT128 | KT128_Managed_Avx2                    | 8KB          |     8,910.6 ns |    175.19 ns |    179.90 ns |    9328 B |
|                                                             |              |                |              |              |           |
| ComputeHash | KT128 | KT128_Managed_Scalar                  | 128KB        |    91,995.3 ns |  1,519.68 ns |  1,421.51 ns |   16888 B |
| ComputeHash | KT128 | KT128_Managed_Ssse3                   | 128KB        |   109,824.8 ns |  2,090.62 ns |  1,853.28 ns |   16888 B |
| ComputeHash | KT128 | KT128_Managed_Avx512F                 | 128KB        |   118,438.4 ns |  1,269.67 ns |  1,125.53 ns |   16888 B |
| ComputeHash | KT128 | KT128_Managed_Avx2                    | 128KB        |   129,663.2 ns |    927.73 ns |    774.70 ns |   16888 B |
|                                                             |              |                |              |              |           |
| ComputeHash | KT256 | KT256_Managed_Scalar                  | 128B         |       232.0 ns |      4.22 ns |      5.02 ns |     616 B |
| ComputeHash | KT256 | KT256_Managed_Ssse3                   | 128B         |       257.6 ns |      4.38 ns |      4.10 ns |     616 B |
| ComputeHash | KT256 | KT256_Managed_Avx512F                 | 128B         |       260.9 ns |      3.45 ns |      3.23 ns |     616 B |
| ComputeHash | KT256 | KT256_Managed_Avx2                    | 128B         |       272.9 ns |      3.30 ns |      3.09 ns |     616 B |
|                                                             |              |                |              |              |           |
| ComputeHash | KT256 | KT256_Managed_Scalar                  | 137B         |       399.1 ns |      5.19 ns |      4.85 ns |     616 B |
| ComputeHash | KT256 | KT256_Managed_Avx512F                 | 137B         |       440.2 ns |      2.38 ns |      2.11 ns |     616 B |
| ComputeHash | KT256 | KT256_Managed_Ssse3                   | 137B         |       451.2 ns |      5.71 ns |      4.76 ns |     616 B |
| ComputeHash | KT256 | KT256_Managed_Avx2                    | 137B         |       477.8 ns |      3.84 ns |      3.21 ns |     616 B |
|                                                             |              |                |              |              |           |
| ComputeHash | KT256 | KT256_Managed_Scalar                  | 1KB          |     1,049.4 ns |     11.46 ns |     10.16 ns |     616 B |
| ComputeHash | KT256 | KT256_Managed_Ssse3                   | 1KB          |     1,215.2 ns |     15.58 ns |     13.01 ns |     616 B |
| ComputeHash | KT256 | KT256_Managed_Avx512F                 | 1KB          |     1,298.0 ns |      5.78 ns |      4.83 ns |     616 B |
| ComputeHash | KT256 | KT256_Managed_Avx2                    | 1KB          |     1,454.9 ns |     25.80 ns |     24.13 ns |     616 B |
|                                                             |              |                |              |              |           |
| ComputeHash | KT256 | KT256_Managed_Scalar                  | 1025B        |     1,082.2 ns |     21.42 ns |     23.80 ns |     616 B |
| ComputeHash | KT256 | KT256_Managed_Ssse3                   | 1025B        |     1,253.0 ns |     19.57 ns |     20.09 ns |     616 B |
| ComputeHash | KT256 | KT256_Managed_Avx512F                 | 1025B        |     1,309.6 ns |      7.16 ns |      5.98 ns |     616 B |
| ComputeHash | KT256 | KT256_Managed_Avx2                    | 1025B        |     1,424.1 ns |      7.57 ns |      6.71 ns |     616 B |
|                                                             |              |                |              |              |           |
| ComputeHash | KT256 | KT256_Managed_Scalar                  | 8KB          |     7,757.1 ns |    131.91 ns |    116.93 ns |    9360 B |
| ComputeHash | KT256 | KT256_Managed_Ssse3                   | 8KB          |     9,072.6 ns |     93.98 ns |     78.48 ns |    9360 B |
| ComputeHash | KT256 | KT256_Managed_Avx512F                 | 8KB          |     9,666.9 ns |    169.53 ns |    158.58 ns |    9360 B |
| ComputeHash | KT256 | KT256_Managed_Avx2                    | 8KB          |    10,742.1 ns |    169.85 ns |    158.87 ns |    9360 B |
|                                                             |              |                |              |              |           |
| ComputeHash | KT256 | KT256_Managed_Scalar                  | 128KB        |   115,976.6 ns |  1,923.74 ns |  1,705.34 ns |   16920 B |
| ComputeHash | KT256 | KT256_Managed_Ssse3                   | 128KB        |   137,354.9 ns |  2,327.14 ns |  2,062.95 ns |   16920 B |
| ComputeHash | KT256 | KT256_Managed_Avx512F                 | 128KB        |   147,193.4 ns |  2,686.74 ns |  2,513.18 ns |   16920 B |
| ComputeHash | KT256 | KT256_Managed_Avx2                    | 128KB        |   162,129.4 ns |  2,313.80 ns |  2,051.12 ns |   16920 B |
|                                                             |              |                |              |              |           |
| ComputeHash | MD5 | OS Native                               | 128B         |       297.7 ns |      2.34 ns |      1.82 ns |      80 B |
| **ComputeHash | MD5 | CryptoHives**                             | **128B**         |       **366.7 ns** |      **6.58 ns** |      **6.16 ns** |      **80 B** |
| **ComputeHash | MD5 | BouncyCastle**                            | **128B**         |       **405.7 ns** |      **6.29 ns** |      **5.88 ns** |      **80 B** |
|                                                             |              |                |              |              |           |
| ComputeHash | MD5 | OS Native                               | 137B         |       293.4 ns |      1.83 ns |      1.71 ns |      80 B |
| **ComputeHash | MD5 | CryptoHives**                             | **137B**         |       **371.2 ns** |      **6.36 ns** |      **5.95 ns** |      **80 B** |
| **ComputeHash | MD5 | BouncyCastle**                            | **137B**         |       **399.4 ns** |      **3.39 ns** |      **3.17 ns** |      **80 B** |
|                                                             |              |                |              |              |           |
| ComputeHash | MD5 | OS Native                               | 1KB          |     1,397.8 ns |      9.68 ns |      7.55 ns |      80 B |
| **ComputeHash | MD5 | CryptoHives**                             | **1KB**          |     **1,874.2 ns** |     **34.89 ns** |     **34.26 ns** |      **80 B** |
| **ComputeHash | MD5 | BouncyCastle**                            | **1KB**          |     **2,038.9 ns** |     **10.67 ns** |      **9.46 ns** |      **80 B** |
|                                                             |              |                |              |              |           |
| ComputeHash | MD5 | OS Native                               | 1025B        |     1,418.1 ns |     27.56 ns |     27.07 ns |      80 B |
| **ComputeHash | MD5 | CryptoHives**                             | **1025B**        |     **1,893.9 ns** |     **35.79 ns** |     **33.48 ns** |      **80 B** |
| **ComputeHash | MD5 | BouncyCastle**                            | **1025B**        |     **2,038.1 ns** |      **7.26 ns** |      **6.79 ns** |      **80 B** |
|                                                             |              |                |              |              |           |
| ComputeHash | MD5 | OS Native                               | 8KB          |    10,329.4 ns |    156.29 ns |    146.19 ns |      80 B |
| **ComputeHash | MD5 | CryptoHives**                             | **8KB**          |    **13,815.0 ns** |    **131.79 ns** |    **123.27 ns** |      **80 B** |
| **ComputeHash | MD5 | BouncyCastle**                            | **8KB**          |    **15,181.9 ns** |     **57.24 ns** |     **53.54 ns** |      **80 B** |
|                                                             |              |                |              |              |           |
| ComputeHash | MD5 | OS Native                               | 128KB        |   161,292.0 ns |    479.59 ns |    425.14 ns |      80 B |
| **ComputeHash | MD5 | CryptoHives**                             | **128KB**        |   **222,702.8 ns** |  **4,190.74 ns** |  **3,920.02 ns** |      **80 B** |
| **ComputeHash | MD5 | BouncyCastle**                            | **128KB**        |   **242,640.2 ns** |  **4,641.51 ns** |  **4,966.36 ns** |      **80 B** |
|                                                             |              |                |              |              |           |
| ComputeHash | RIPEMD-160 | BouncyCastle                     | 128B         |       678.3 ns |      5.39 ns |      5.04 ns |      96 B |
| **ComputeHash | RIPEMD-160 | CryptoHives**                      | **128B**         |     **1,056.6 ns** |     **20.91 ns** |     **43.64 ns** |      **96 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | RIPEMD-160 | BouncyCastle**                     | **137B**         |       **672.0 ns** |      **4.30 ns** |      **3.59 ns** |      **96 B** |
| **ComputeHash | RIPEMD-160 | CryptoHives**                      | **137B**         |     **1,024.7 ns** |     **19.79 ns** |     **21.17 ns** |      **96 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | RIPEMD-160 | BouncyCastle**                     | **1KB**          |     **3,610.1 ns** |     **56.59 ns** |     **52.94 ns** |      **96 B** |
| **ComputeHash | RIPEMD-160 | CryptoHives**                      | **1KB**          |     **5,679.3 ns** |    **110.36 ns** |    **113.33 ns** |      **96 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | RIPEMD-160 | BouncyCastle**                     | **1025B**        |     **3,594.0 ns** |     **21.43 ns** |     **20.05 ns** |      **96 B** |
| **ComputeHash | RIPEMD-160 | CryptoHives**                      | **1025B**        |     **5,762.0 ns** |     **61.29 ns** |     **54.33 ns** |      **96 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | RIPEMD-160 | BouncyCastle**                     | **8KB**          |    **27,123.5 ns** |    **448.44 ns** |    **419.47 ns** |      **96 B** |
| **ComputeHash | RIPEMD-160 | CryptoHives**                      | **8KB**          |    **42,187.5 ns** |    **575.78 ns** |    **538.59 ns** |      **96 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | RIPEMD-160 | BouncyCastle**                     | **128KB**        |   **428,621.1 ns** |  **2,591.09 ns** |  **2,296.94 ns** |      **96 B** |
| **ComputeHash | RIPEMD-160 | CryptoHives**                      | **128KB**        |   **675,088.4 ns** | **11,875.78 ns** | **11,108.61 ns** |      **96 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-1 | OS Native**                             | **128B**         |       **255.7 ns** |      **1.46 ns** |      **1.14 ns** |      **96 B** |
| ComputeHash | SHA-1 | BouncyCastle                          | 128B         |       475.6 ns |      9.47 ns |      8.86 ns |      96 B |
| **ComputeHash | SHA-1 | CryptoHives**                           | **128B**         |       **494.8 ns** |      **7.99 ns** |      **7.09 ns** |      **96 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-1 | OS Native**                             | **137B**         |       **259.1 ns** |      **3.25 ns** |      **3.04 ns** |      **96 B** |
| ComputeHash | SHA-1 | BouncyCastle                          | 137B         |       472.8 ns |      4.64 ns |      4.34 ns |      96 B |
| **ComputeHash | SHA-1 | CryptoHives**                           | **137B**         |       **491.8 ns** |      **4.26 ns** |      **3.77 ns** |      **96 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-1 | OS Native**                             | **1KB**          |     **1,140.6 ns** |     **11.64 ns** |     **10.89 ns** |      **96 B** |
| ComputeHash | SHA-1 | BouncyCastle                          | 1KB          |     2,466.9 ns |     29.65 ns |     27.74 ns |      96 B |
| **ComputeHash | SHA-1 | CryptoHives**                           | **1KB**          |     **2,510.4 ns** |     **32.52 ns** |     **30.42 ns** |      **96 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-1 | OS Native**                             | **1025B**        |     **1,138.6 ns** |     **11.50 ns** |     **10.76 ns** |      **96 B** |
| ComputeHash | SHA-1 | BouncyCastle                          | 1025B        |     2,466.4 ns |     24.40 ns |     22.82 ns |      96 B |
| **ComputeHash | SHA-1 | CryptoHives**                           | **1025B**        |     **2,574.4 ns** |     **37.73 ns** |     **35.29 ns** |      **96 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-1 | OS Native**                             | **8KB**          |     **8,164.3 ns** |     **97.20 ns** |     **86.16 ns** |      **96 B** |
| ComputeHash | SHA-1 | BouncyCastle                          | 8KB          |    18,359.2 ns |    234.16 ns |    219.04 ns |      96 B |
| **ComputeHash | SHA-1 | CryptoHives**                           | **8KB**          |    **18,597.8 ns** |    **300.76 ns** |    **281.33 ns** |      **96 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-1 | OS Native**                             | **128KB**        |   **129,563.1 ns** |  **1,341.53 ns** |  **1,254.87 ns** |      **96 B** |
| ComputeHash | SHA-1 | BouncyCastle                          | 128KB        |   289,878.0 ns |  2,585.71 ns |  2,418.67 ns |      96 B |
| **ComputeHash | SHA-1 | CryptoHives**                           | **128KB**        |   **295,541.5 ns** |  **2,813.34 ns** |  **2,493.95 ns** |      **96 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-224 | BouncyCastle**                        | **128B**         |       **593.5 ns** |     **11.52 ns** |     **12.80 ns** |     **112 B** |
| **ComputeHash | SHA-224 | CryptoHives**                         | **128B**         |       **605.4 ns** |      **9.26 ns** |      **8.20 ns** |     **112 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-224 | BouncyCastle**                        | **137B**         |       **606.2 ns** |      **7.80 ns** |      **6.92 ns** |     **112 B** |
| **ComputeHash | SHA-224 | CryptoHives**                         | **137B**         |       **627.5 ns** |     **11.72 ns** |     **10.96 ns** |     **112 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-224 | BouncyCastle**                        | **1KB**          |     **3,191.8 ns** |     **50.47 ns** |     **47.21 ns** |     **112 B** |
| **ComputeHash | SHA-224 | CryptoHives**                         | **1KB**          |     **3,243.5 ns** |     **33.74 ns** |     **31.56 ns** |     **112 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-224 | BouncyCastle**                        | **1025B**        |     **3,140.4 ns** |     **29.61 ns** |     **27.70 ns** |     **112 B** |
| **ComputeHash | SHA-224 | CryptoHives**                         | **1025B**        |     **3,248.0 ns** |     **40.34 ns** |     **37.74 ns** |     **112 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-224 | BouncyCastle**                        | **8KB**          |    **23,293.7 ns** |    **163.19 ns** |    **136.27 ns** |     **112 B** |
| **ComputeHash | SHA-224 | CryptoHives**                         | **8KB**          |    **24,608.9 ns** |    **441.62 ns** |    **391.48 ns** |     **112 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-224 | BouncyCastle**                        | **128KB**        |   **372,182.0 ns** |  **4,934.27 ns** |  **4,374.10 ns** |     **112 B** |
| **ComputeHash | SHA-224 | CryptoHives**                         | **128KB**        |   **383,529.0 ns** |  **4,072.18 ns** |  **3,609.88 ns** |     **112 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-256 | OS Native**                           | **128B**         |       **132.2 ns** |      **1.87 ns** |      **1.65 ns** |     **112 B** |
| ComputeHash | SHA-256 | BouncyCastle                        | 128B         |       589.9 ns |     10.14 ns |      9.48 ns |     112 B |
| **ComputeHash | SHA-256 | CryptoHives**                         | **128B**         |       **621.3 ns** |      **7.23 ns** |      **6.41 ns** |     **112 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-256 | OS Native**                           | **137B**         |       **132.5 ns** |      **1.69 ns** |      **1.58 ns** |     **112 B** |
| ComputeHash | SHA-256 | BouncyCastle                        | 137B         |       597.0 ns |     10.25 ns |      9.59 ns |     112 B |
| **ComputeHash | SHA-256 | CryptoHives**                         | **137B**         |       **634.5 ns** |     **12.74 ns** |     **12.51 ns** |     **112 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-256 | OS Native**                           | **1KB**          |       **501.6 ns** |      **9.76 ns** |      **9.13 ns** |     **112 B** |
| ComputeHash | SHA-256 | BouncyCastle                        | 1KB          |     3,101.7 ns |     25.70 ns |     24.04 ns |     112 B |
| **ComputeHash | SHA-256 | CryptoHives**                         | **1KB**          |     **3,255.9 ns** |     **39.30 ns** |     **34.84 ns** |     **112 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-256 | OS Native**                           | **1025B**        |       **497.4 ns** |      **3.27 ns** |      **2.73 ns** |     **112 B** |
| ComputeHash | SHA-256 | BouncyCastle                        | 1025B        |     3,090.9 ns |     28.22 ns |     26.40 ns |     112 B |
| **ComputeHash | SHA-256 | CryptoHives**                         | **1025B**        |     **3,231.2 ns** |     **39.77 ns** |     **37.21 ns** |     **112 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-256 | OS Native**                           | **8KB**          |     **3,373.7 ns** |     **37.64 ns** |     **33.37 ns** |     **112 B** |
| ComputeHash | SHA-256 | BouncyCastle                        | 8KB          |    23,180.8 ns |    234.94 ns |    208.26 ns |     112 B |
| **ComputeHash | SHA-256 | CryptoHives**                         | **8KB**          |    **24,875.8 ns** |    **411.49 ns** |    **384.91 ns** |     **112 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-256 | OS Native**                           | **128KB**        |    **53,304.2 ns** |  **1,042.35 ns** |  **1,023.73 ns** |     **112 B** |
| ComputeHash | SHA-256 | BouncyCastle                        | 128KB        |   367,714.5 ns |  4,124.31 ns |  3,857.88 ns |     112 B |
| **ComputeHash | SHA-256 | CryptoHives**                         | **128KB**        |   **389,733.0 ns** |  **7,771.08 ns** |  **7,632.24 ns** |     **112 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-384 | OS Native**                           | **128B**         |       **382.8 ns** |      **4.31 ns** |      **3.82 ns** |     **144 B** |
| ComputeHash | SHA-384 | BouncyCastle                        | 128B         |       520.3 ns |      5.65 ns |      5.28 ns |     144 B |
| **ComputeHash | SHA-384 | CryptoHives**                         | **128B**         |       **556.7 ns** |     **10.55 ns** |     **10.84 ns** |     **144 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-384 | OS Native**                           | **137B**         |       **389.7 ns** |      **4.82 ns** |      **4.51 ns** |     **144 B** |
| ComputeHash | SHA-384 | BouncyCastle                        | 137B         |       528.1 ns |      9.64 ns |      9.02 ns |     144 B |
| **ComputeHash | SHA-384 | CryptoHives**                         | **137B**         |       **549.0 ns** |      **5.20 ns** |      **4.86 ns** |     **144 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-384 | OS Native**                           | **1KB**          |     **1,434.8 ns** |     **19.40 ns** |     **18.15 ns** |     **144 B** |
| ComputeHash | SHA-384 | BouncyCastle                        | 1KB          |     2,159.2 ns |     35.73 ns |     50.08 ns |     144 B |
| **ComputeHash | SHA-384 | CryptoHives**                         | **1KB**          |     **2,177.1 ns** |     **22.15 ns** |     **19.63 ns** |     **144 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-384 | OS Native**                           | **1025B**        |     **1,511.2 ns** |     **30.03 ns** |     **29.49 ns** |     **144 B** |
| ComputeHash | SHA-384 | BouncyCastle                        | 1025B        |     2,223.1 ns |     43.47 ns |     58.03 ns |     144 B |
| **ComputeHash | SHA-384 | CryptoHives**                         | **1025B**        |     **2,251.5 ns** |     **43.57 ns** |     **42.79 ns** |     **144 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-384 | OS Native**                           | **8KB**          |    **10,252.7 ns** |    **203.80 ns** |    **382.78 ns** |     **144 B** |
| **ComputeHash | SHA-384 | CryptoHives**                         | **8KB**          |    **15,576.7 ns** |    **300.56 ns** |    **308.65 ns** |     **144 B** |
| **ComputeHash | SHA-384 | BouncyCastle**                        | **8KB**          |    **15,587.7 ns** |    **306.42 ns** |    **364.78 ns** |     **144 B** |
|                                                             |              |                |              |              |           |
| ComputeHash | SHA-384 | OS Native                           | 128KB        |   154,123.4 ns |  1,574.35 ns |  1,472.64 ns |     144 B |
| **ComputeHash | SHA-384 | CryptoHives**                         | **128KB**        |   **239,998.9 ns** |  **2,495.22 ns** |  **2,211.95 ns** |     **144 B** |
| **ComputeHash | SHA-384 | BouncyCastle**                        | **128KB**        |   **240,610.1 ns** |  **3,524.87 ns** |  **3,297.16 ns** |     **144 B** |
|                                                             |              |                |              |              |           |
| ComputeHash | SHA-512 | OS Native                           | 128B         |       381.3 ns |      4.43 ns |      4.15 ns |     176 B |
| ComputeHash | SHA-512 | BouncyCastle                        | 128B         |       516.4 ns |      5.57 ns |      5.21 ns |     176 B |
| **ComputeHash | SHA-512 | CryptoHives**                         | **128B**         |       **573.9 ns** |      **6.69 ns** |      **5.93 ns** |     **176 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-512 | OS Native**                           | **137B**         |       **381.2 ns** |      **5.13 ns** |      **4.55 ns** |     **176 B** |
| ComputeHash | SHA-512 | BouncyCastle                        | 137B         |       525.6 ns |     10.38 ns |     13.50 ns |     176 B |
| **ComputeHash | SHA-512 | CryptoHives**                         | **137B**         |       **568.1 ns** |      **6.97 ns** |      **6.18 ns** |     **176 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-512 | OS Native**                           | **1KB**          |     **1,490.2 ns** |     **15.01 ns** |     **14.04 ns** |     **176 B** |
| ComputeHash | SHA-512 | BouncyCastle                        | 1KB          |     2,184.4 ns |     41.56 ns |     42.68 ns |     176 B |
| **ComputeHash | SHA-512 | CryptoHives**                         | **1KB**          |     **2,355.3 ns** |     **46.76 ns** |     **64.00 ns** |     **176 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-512 | OS Native**                           | **1025B**        |     **1,427.3 ns** |     **13.68 ns** |     **12.80 ns** |     **176 B** |
| ComputeHash | SHA-512 | BouncyCastle                        | 1025B        |     2,127.2 ns |     20.65 ns |     18.31 ns |     176 B |
| **ComputeHash | SHA-512 | CryptoHives**                         | **1025B**        |     **2,276.0 ns** |     **24.89 ns** |     **22.07 ns** |     **176 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-512 | OS Native**                           | **8KB**          |     **9,844.6 ns** |    **114.23 ns** |    **106.85 ns** |     **176 B** |
| ComputeHash | SHA-512 | BouncyCastle                        | 8KB          |    15,019.9 ns |     95.37 ns |     84.54 ns |     176 B |
| **ComputeHash | SHA-512 | CryptoHives**                         | **8KB**          |    **15,840.4 ns** |    **260.50 ns** |    **243.67 ns** |     **176 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-512 | OS Native**                           | **128KB**        |   **153,343.7 ns** |  **1,395.42 ns** |  **1,237.00 ns** |     **176 B** |
| ComputeHash | SHA-512 | BouncyCastle                        | 128KB        |   240,202.7 ns |  3,135.58 ns |  2,933.02 ns |     176 B |
| **ComputeHash | SHA-512 | CryptoHives**                         | **128KB**        |   **252,187.6 ns** |  **3,456.56 ns** |  **3,233.27 ns** |     **179 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-512/224 | BouncyCastle**                    | **128B**         |       **521.6 ns** |      **6.07 ns** |      **5.67 ns** |     **112 B** |
| **ComputeHash | SHA-512/224 | CryptoHives**                     | **128B**         |       **546.8 ns** |      **6.29 ns** |      **5.88 ns** |     **112 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-512/224 | BouncyCastle**                    | **137B**         |       **540.9 ns** |      **7.96 ns** |      **7.44 ns** |     **112 B** |
| **ComputeHash | SHA-512/224 | CryptoHives**                     | **137B**         |       **553.3 ns** |      **8.38 ns** |      **7.84 ns** |     **112 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-512/224 | BouncyCastle**                    | **1KB**          |     **2,180.6 ns** |     **23.24 ns** |     **21.73 ns** |     **112 B** |
| **ComputeHash | SHA-512/224 | CryptoHives**                     | **1KB**          |     **2,205.0 ns** |     **25.21 ns** |     **23.58 ns** |     **112 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-512/224 | BouncyCastle**                    | **1025B**        |     **2,197.6 ns** |     **28.78 ns** |     **26.92 ns** |     **112 B** |
| **ComputeHash | SHA-512/224 | CryptoHives**                     | **1025B**        |     **2,238.1 ns** |     **44.72 ns** |     **41.83 ns** |     **112 B** |
|                                                             |              |                |              |              |           |
| ComputeHash | SHA-512/224 | CryptoHives                     | 8KB          |    15,246.0 ns |    200.66 ns |    187.69 ns |     112 B |
| **ComputeHash | SHA-512/224 | BouncyCastle**                    | **8KB**          |    **15,396.8 ns** |    **161.31 ns** |    **150.88 ns** |     **112 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-512/224 | CryptoHives**                     | **128KB**        |   **240,324.5 ns** |  **2,219.12 ns** |  **2,075.76 ns** |     **112 B** |
| **ComputeHash | SHA-512/224 | BouncyCastle**                    | **128KB**        |   **242,191.4 ns** |  **2,883.88 ns** |  **2,556.49 ns** |     **112 B** |
|                                                             |              |                |              |              |           |
| ComputeHash | SHA-512/256 | BouncyCastle                    | 128B         |       542.9 ns |      8.69 ns |      8.13 ns |     112 B |
| **ComputeHash | SHA-512/256 | CryptoHives**                     | **128B**         |       **560.4 ns** |      **8.75 ns** |      **7.75 ns** |     **112 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-512/256 | BouncyCastle**                    | **137B**         |       **540.1 ns** |      **4.93 ns** |      **4.37 ns** |     **112 B** |
| **ComputeHash | SHA-512/256 | CryptoHives**                     | **137B**         |       **556.9 ns** |      **5.50 ns** |      **5.14 ns** |     **112 B** |
|                                                             |              |                |              |              |           |
| ComputeHash | SHA-512/256 | CryptoHives                     | 1KB          |     2,207.7 ns |     31.61 ns |     29.57 ns |     112 B |
| **ComputeHash | SHA-512/256 | BouncyCastle**                    | **1KB**          |     **2,209.5 ns** |     **30.35 ns** |     **28.38 ns** |     **112 B** |
|                                                             |              |                |              |              |           |
| ComputeHash | SHA-512/256 | BouncyCastle                    | 1025B        |     2,183.9 ns |     27.77 ns |     25.98 ns |     112 B |
| **ComputeHash | SHA-512/256 | CryptoHives**                     | **1025B**        |     **2,228.7 ns** |     **37.09 ns** |     **34.70 ns** |     **112 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-512/256 | BouncyCastle**                    | **8KB**          |    **15,209.6 ns** |    **202.82 ns** |    **179.79 ns** |     **112 B** |
| **ComputeHash | SHA-512/256 | CryptoHives**                     | **8KB**          |    **15,353.5 ns** |    **191.80 ns** |    **179.41 ns** |     **112 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA-512/256 | BouncyCastle**                    | **128KB**        |   **240,233.8 ns** |  **2,657.90 ns** |  **2,486.20 ns** |     **112 B** |
| **ComputeHash | SHA-512/256 | CryptoHives**                     | **128KB**        |   **241,412.8 ns** |  **3,228.52 ns** |  **3,019.96 ns** |     **112 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SHA3-224 | SHA3_224_Managed_Scalar**            | **128B**         |       **248.6 ns** |      **3.89 ns** |      **3.64 ns** |     **112 B** |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Ssse3             | 128B         |       298.2 ns |      3.44 ns |      3.22 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx512F           | 128B         |       324.8 ns |      5.49 ns |      5.13 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx2              | 128B         |       346.6 ns |      4.57 ns |      4.27 ns |     112 B |
| ComputeHash | SHA3-224 | BouncyCastle                       | 128B         |       372.7 ns |      6.49 ns |      6.07 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Scalar            | 137B         |       245.6 ns |      2.41 ns |      2.13 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Ssse3             | 137B         |       291.6 ns |      5.72 ns |      5.62 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx512F           | 137B         |       319.6 ns |      4.95 ns |      4.63 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx2              | 137B         |       342.4 ns |      1.64 ns |      1.37 ns |     112 B |
| ComputeHash | SHA3-224 | BouncyCastle                       | 137B         |       375.3 ns |      7.20 ns |      6.01 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Scalar            | 1KB          |     1,738.9 ns |     19.55 ns |     17.33 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Ssse3             | 1KB          |     2,080.4 ns |     36.90 ns |     32.71 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx512F           | 1KB          |     2,276.1 ns |     32.47 ns |     37.39 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx2              | 1KB          |     2,539.7 ns |     38.21 ns |     35.74 ns |     112 B |
| ComputeHash | SHA3-224 | BouncyCastle                       | 1KB          |     2,560.8 ns |     22.93 ns |     21.45 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Scalar            | 1025B        |     1,763.7 ns |     29.82 ns |     27.89 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Ssse3             | 1025B        |     2,081.2 ns |     39.51 ns |     36.96 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx512F           | 1025B        |     2,280.7 ns |     43.87 ns |     43.08 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx2              | 1025B        |     2,500.7 ns |     15.87 ns |     14.84 ns |     112 B |
| ComputeHash | SHA3-224 | BouncyCastle                       | 1025B        |     2,589.1 ns |     44.24 ns |     41.38 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Scalar            | 8KB          |    11,612.9 ns |    185.28 ns |    164.25 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Ssse3             | 8KB          |    13,947.0 ns |    162.01 ns |    135.29 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx512F           | 8KB          |    15,428.2 ns |     83.33 ns |     69.58 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx2              | 8KB          |    17,357.5 ns |    311.39 ns |    291.27 ns |     112 B |
| ComputeHash | SHA3-224 | BouncyCastle                       | 8KB          |    17,730.7 ns |    179.91 ns |    168.29 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Scalar            | 128KB        |   184,466.2 ns |  2,098.62 ns |  1,963.05 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Ssse3             | 128KB        |   223,144.1 ns |  2,564.67 ns |  2,399.00 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx512F           | 128KB        |   246,553.4 ns |  4,198.59 ns |  3,927.36 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx2              | 128KB        |   273,074.0 ns |  1,211.56 ns |  1,074.02 ns |     112 B |
| ComputeHash | SHA3-224 | BouncyCastle                       | 128KB        |   281,358.8 ns |  2,697.30 ns |  2,523.05 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar            | 128B         |       243.7 ns |      3.05 ns |      2.71 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Ssse3             | 128B         |       285.0 ns |      5.43 ns |      5.81 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native                          | 128B         |       305.6 ns |      5.30 ns |      4.96 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx512F           | 128B         |       314.6 ns |      3.78 ns |      3.53 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2              | 128B         |       345.4 ns |      6.62 ns |      6.80 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle                       | 128B         |       369.4 ns |      7.34 ns |      6.87 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar            | 137B         |       493.4 ns |      8.87 ns |      8.30 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native                          | 137B         |       543.1 ns |     10.78 ns |     10.08 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Ssse3             | 137B         |       575.9 ns |      9.51 ns |      8.89 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx512F           | 137B         |       640.8 ns |      8.56 ns |      8.01 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle                       | 137B         |       665.9 ns |     12.65 ns |     12.42 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2              | 137B         |       693.6 ns |     13.50 ns |     12.63 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar            | 1KB          |     1,695.2 ns |     25.33 ns |     23.70 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native                          | 1KB          |     1,994.4 ns |     35.54 ns |     33.25 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Ssse3             | 1KB          |     2,015.4 ns |     27.23 ns |     25.47 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx512F           | 1KB          |     2,240.3 ns |     38.08 ns |     35.62 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2              | 1KB          |     2,463.7 ns |     17.75 ns |     14.82 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle                       | 1KB          |     2,532.7 ns |     31.51 ns |     29.47 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar            | 1025B        |     1,681.8 ns |     26.52 ns |     24.81 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native                          | 1025B        |     1,989.9 ns |     36.67 ns |     34.30 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Ssse3             | 1025B        |     2,037.3 ns |     33.87 ns |     31.68 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx512F           | 1025B        |     2,199.3 ns |     11.12 ns |      9.86 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2              | 1025B        |     2,483.8 ns |     41.61 ns |     38.92 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle                       | 1025B        |     2,528.8 ns |     32.60 ns |     30.49 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar            | 8KB          |    12,468.7 ns |    205.87 ns |    192.57 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native                          | 8KB          |    14,743.1 ns |    224.77 ns |    210.25 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Ssse3             | 8KB          |    14,970.0 ns |    230.04 ns |    215.18 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx512F           | 8KB          |    16,507.2 ns |    246.30 ns |    230.39 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2              | 8KB          |    18,493.3 ns |    247.93 ns |    231.91 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle                       | 8KB          |    19,038.4 ns |    298.95 ns |    279.64 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar            | 128KB        |   194,851.8 ns |  2,290.69 ns |  2,142.71 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native                          | 128KB        |   231,350.3 ns |  3,058.70 ns |  2,861.11 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Ssse3             | 128KB        |   235,177.9 ns |  3,942.02 ns |  3,687.37 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx512F           | 128KB        |   260,636.5 ns |  4,743.23 ns |  4,436.82 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx2              | 128KB        |   291,718.7 ns |  4,539.45 ns |  4,246.21 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle                       | 128KB        |   297,835.6 ns |  3,970.27 ns |  3,315.35 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Scalar            | 128B         |       470.7 ns |      9.15 ns |      8.99 ns |     144 B |
| ComputeHash | SHA3-384 | OS Native                          | 128B         |       541.1 ns |      9.63 ns |      9.01 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Ssse3             | 128B         |       548.0 ns |      5.59 ns |      5.23 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx512F           | 128B         |       614.5 ns |      8.61 ns |      8.05 ns |     144 B |
| ComputeHash | SHA3-384 | BouncyCastle                       | 128B         |       668.4 ns |      9.37 ns |      8.76 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx2              | 128B         |       670.2 ns |     10.00 ns |      8.86 ns |     144 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Scalar            | 137B         |       457.0 ns |      2.90 ns |      2.71 ns |     144 B |
| ComputeHash | SHA3-384 | OS Native                          | 137B         |       541.0 ns |      6.98 ns |      6.53 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Ssse3             | 137B         |       541.9 ns |      4.68 ns |      4.15 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx512F           | 137B         |       609.5 ns |     12.00 ns |     10.02 ns |     144 B |
| ComputeHash | SHA3-384 | BouncyCastle                       | 137B         |       655.6 ns |      3.11 ns |      2.76 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx2              | 137B         |       656.8 ns |      1.15 ns |      0.90 ns |     144 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Scalar            | 1KB          |     2,030.2 ns |      9.94 ns |      8.30 ns |     144 B |
| ComputeHash | SHA3-384 | OS Native                          | 1KB          |     2,425.4 ns |     10.19 ns |      7.95 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Ssse3             | 1KB          |     2,461.3 ns |      8.31 ns |      6.49 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx512F           | 1KB          |     2,712.4 ns |     11.76 ns |      9.82 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx2              | 1KB          |     3,022.7 ns |      4.79 ns |      4.24 ns |     144 B |
| ComputeHash | SHA3-384 | BouncyCastle                       | 1KB          |     3,084.0 ns |     14.72 ns |     13.77 ns |     144 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Scalar            | 1025B        |     2,030.1 ns |     15.96 ns |     14.14 ns |     144 B |
| ComputeHash | SHA3-384 | OS Native                          | 1025B        |     2,430.2 ns |     18.14 ns |     16.08 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Ssse3             | 1025B        |     2,439.2 ns |     13.02 ns |     11.54 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx512F           | 1025B        |     2,701.9 ns |      5.08 ns |      4.50 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx2              | 1025B        |     3,015.4 ns |      5.83 ns |      5.46 ns |     144 B |
| ComputeHash | SHA3-384 | BouncyCastle                       | 1025B        |     3,077.8 ns |      9.39 ns |      8.78 ns |     144 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Scalar            | 8KB          |    15,758.5 ns |     30.05 ns |     23.46 ns |     144 B |
| ComputeHash | SHA3-384 | OS Native                          | 8KB          |    18,548.9 ns |    110.54 ns |     97.99 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Ssse3             | 8KB          |    18,906.5 ns |     75.10 ns |     66.57 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx512F           | 8KB          |    20,980.7 ns |     35.03 ns |     29.25 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx2              | 8KB          |    23,587.9 ns |     54.28 ns |     48.12 ns |     144 B |
| ComputeHash | SHA3-384 | BouncyCastle                       | 8KB          |    23,978.2 ns |     94.22 ns |     78.68 ns |     144 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Scalar            | 128KB        |   250,177.5 ns |  1,706.92 ns |  1,596.65 ns |     144 B |
| ComputeHash | SHA3-384 | OS Native                          | 128KB        |   295,441.9 ns |  1,576.47 ns |  1,316.42 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Ssse3             | 128KB        |   301,345.8 ns |  1,763.32 ns |  1,649.41 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx512F           | 128KB        |   333,494.5 ns |    599.94 ns |    468.39 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx2              | 128KB        |   375,033.9 ns |  1,177.66 ns |    983.40 ns |     144 B |
| ComputeHash | SHA3-384 | BouncyCastle                       | 128KB        |   382,213.6 ns |  2,264.40 ns |  2,118.12 ns |     144 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Scalar            | 128B         |       434.0 ns |      3.06 ns |      2.86 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Ssse3             | 128B         |       516.9 ns |      3.25 ns |      3.04 ns |     176 B |
| ComputeHash | SHA3-512 | OS Native                          | 128B         |       534.6 ns |      4.82 ns |      4.27 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx512F           | 128B         |       574.9 ns |      1.75 ns |      1.55 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx2              | 128B         |       636.6 ns |      2.68 ns |      2.51 ns |     176 B |
| ComputeHash | SHA3-512 | BouncyCastle                       | 128B         |       652.1 ns |      2.99 ns |      2.50 ns |     176 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Scalar            | 137B         |       433.2 ns |      5.32 ns |      4.72 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Ssse3             | 137B         |       512.8 ns |      2.79 ns |      2.61 ns |     176 B |
| ComputeHash | SHA3-512 | OS Native                          | 137B         |       535.7 ns |      6.95 ns |      6.50 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx512F           | 137B         |       574.2 ns |      2.77 ns |      2.59 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx2              | 137B         |       630.6 ns |      1.28 ns |      1.07 ns |     176 B |
| ComputeHash | SHA3-512 | BouncyCastle                       | 137B         |       652.1 ns |      3.15 ns |      2.95 ns |     176 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Scalar            | 1KB          |     3,011.4 ns |     22.33 ns |     20.89 ns |     176 B |
| ComputeHash | SHA3-512 | OS Native                          | 1KB          |     3,564.5 ns |     23.81 ns |     22.27 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Ssse3             | 1KB          |     3,620.0 ns |      9.76 ns |      8.66 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx512F           | 1KB          |     4,058.2 ns |     12.63 ns |     10.54 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx2              | 1KB          |     4,510.5 ns |     10.64 ns |      9.43 ns |     176 B |
| ComputeHash | SHA3-512 | BouncyCastle                       | 1KB          |     4,542.3 ns |     25.40 ns |     23.76 ns |     176 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Scalar            | 1025B        |     3,008.4 ns |     23.87 ns |     22.33 ns |     176 B |
| ComputeHash | SHA3-512 | OS Native                          | 1025B        |     3,571.9 ns |     20.80 ns |     18.44 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Ssse3             | 1025B        |     3,618.2 ns |     14.64 ns |     13.70 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx512F           | 1025B        |     4,039.4 ns |     13.41 ns |     12.54 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx2              | 1025B        |     4,512.5 ns |     15.77 ns |     14.75 ns |     176 B |
| ComputeHash | SHA3-512 | BouncyCastle                       | 1025B        |     4,539.1 ns |     24.44 ns |     21.67 ns |     176 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Scalar            | 8KB          |    22,431.5 ns |    138.48 ns |    129.53 ns |     176 B |
| ComputeHash | SHA3-512 | OS Native                          | 8KB          |    26,505.8 ns |     94.52 ns |     83.79 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Ssse3             | 8KB          |    27,120.0 ns |    181.99 ns |    170.23 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx512F           | 8KB          |    30,203.7 ns |     60.06 ns |     56.18 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx2              | 8KB          |    33,858.0 ns |    104.96 ns |     98.18 ns |     176 B |
| ComputeHash | SHA3-512 | BouncyCastle                       | 8KB          |    34,469.2 ns |    277.68 ns |    246.15 ns |     176 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Scalar            | 128KB        |   356,455.7 ns |  1,745.04 ns |  1,546.93 ns |     176 B |
| ComputeHash | SHA3-512 | OS Native                          | 128KB        |   422,827.5 ns |  1,508.39 ns |  1,410.95 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Ssse3             | 128KB        |   433,338.6 ns |  2,257.25 ns |  2,111.43 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx512F           | 128KB        |   480,876.2 ns |    878.28 ns |    778.58 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx2              | 128KB        |   540,323.0 ns |  1,435.50 ns |  1,272.54 ns |     176 B |
| ComputeHash | SHA3-512 | BouncyCastle                       | 128KB        |   550,564.3 ns |  4,201.80 ns |  3,930.37 ns |     176 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHAKE128 | Shake128_Managed_Scalar            | 128B         |       271.2 ns |      1.72 ns |      1.53 ns |     112 B |
| ComputeHash | SHAKE128 | Shake128_Managed_Ssse3             | 128B         |       315.2 ns |      2.72 ns |      2.55 ns |     112 B |
| ComputeHash | SHAKE128 | Shake128_Managed_Avx512F           | 128B         |       342.1 ns |      0.76 ns |      0.67 ns |     112 B |
| ComputeHash | SHAKE128 | Shake128_Managed_Avx2              | 128B         |       352.6 ns |      0.96 ns |      0.90 ns |     112 B |
| ComputeHash | SHAKE128 | BouncyCastle                       | 128B         |       360.0 ns |      2.13 ns |      1.99 ns |     112 B |
| ComputeHash | SHAKE128 | OS Native                          | 128B         |       379.9 ns |      1.73 ns |      1.62 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHAKE128 | Shake128_Managed_Scalar            | 137B         |       267.1 ns |      1.81 ns |      1.70 ns |     112 B |
| ComputeHash | SHAKE128 | Shake128_Managed_Ssse3             | 137B         |       312.2 ns |      1.59 ns |      1.48 ns |     112 B |
| ComputeHash | SHAKE128 | Shake128_Managed_Avx512F           | 137B         |       341.1 ns |      1.20 ns |      1.06 ns |     112 B |
| ComputeHash | SHAKE128 | Shake128_Managed_Avx2              | 137B         |       349.8 ns |      0.82 ns |      0.73 ns |     112 B |
| ComputeHash | SHAKE128 | BouncyCastle                       | 137B         |       366.4 ns |      1.94 ns |      1.81 ns |     112 B |
| ComputeHash | SHAKE128 | OS Native                          | 137B         |       384.0 ns |      2.31 ns |      2.16 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHAKE128 | Shake128_Managed_Scalar            | 1KB          |     1,527.7 ns |      6.59 ns |      6.16 ns |     112 B |
| ComputeHash | SHAKE128 | Shake128_Managed_Ssse3             | 1KB          |     1,802.0 ns |      9.37 ns |      7.82 ns |     112 B |
| ComputeHash | SHAKE128 | OS Native                          | 1KB          |     1,802.4 ns |     14.86 ns |     13.17 ns |     112 B |
| ComputeHash | SHAKE128 | Shake128_Managed_Avx512F           | 1KB          |     1,996.7 ns |      6.72 ns |      5.96 ns |     112 B |
| ComputeHash | SHAKE128 | BouncyCastle                       | 1KB          |     2,200.0 ns |     11.30 ns |     10.02 ns |     112 B |
| ComputeHash | SHAKE128 | Shake128_Managed_Avx2              | 1KB          |     2,212.7 ns |      8.60 ns |      8.05 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHAKE128 | Shake128_Managed_Scalar            | 1025B        |     1,519.9 ns |      6.74 ns |      6.30 ns |     112 B |
| ComputeHash | SHAKE128 | OS Native                          | 1025B        |     1,798.6 ns |      8.88 ns |      7.88 ns |     112 B |
| ComputeHash | SHAKE128 | Shake128_Managed_Ssse3             | 1025B        |     1,807.9 ns |     12.27 ns |     11.48 ns |     112 B |
| ComputeHash | SHAKE128 | Shake128_Managed_Avx512F           | 1025B        |     1,997.0 ns |      6.90 ns |      6.45 ns |     112 B |
| ComputeHash | SHAKE128 | BouncyCastle                       | 1025B        |     2,191.9 ns |      9.66 ns |      8.06 ns |     112 B |
| ComputeHash | SHAKE128 | Shake128_Managed_Avx2              | 1025B        |     2,211.9 ns |      7.78 ns |      7.28 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHAKE128 | Shake128_Managed_Scalar            | 8KB          |     9,899.1 ns |     60.27 ns |     56.38 ns |     112 B |
| ComputeHash | SHAKE128 | OS Native                          | 8KB          |    11,823.1 ns |     80.27 ns |     75.08 ns |     112 B |
| ComputeHash | SHAKE128 | Shake128_Managed_Ssse3             | 8KB          |    11,933.0 ns |     90.46 ns |     80.19 ns |     112 B |
| ComputeHash | SHAKE128 | Shake128_Managed_Avx512F           | 8KB          |    13,204.6 ns |     23.58 ns |     22.06 ns |     112 B |
| ComputeHash | SHAKE128 | Shake128_Managed_Avx2              | 8KB          |    14,771.8 ns |     35.85 ns |     33.53 ns |     112 B |
| ComputeHash | SHAKE128 | BouncyCastle                       | 8KB          |    15,117.5 ns |     44.11 ns |     39.10 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHAKE128 | Shake128_Managed_Scalar            | 128KB        |   156,637.0 ns |    714.29 ns |    633.20 ns |     112 B |
| ComputeHash | SHAKE128 | OS Native                          | 128KB        |   185,430.3 ns |    916.68 ns |    765.47 ns |     112 B |
| ComputeHash | SHAKE128 | Shake128_Managed_Ssse3             | 128KB        |   189,251.0 ns |  1,060.15 ns |    991.67 ns |     112 B |
| ComputeHash | SHAKE128 | Shake128_Managed_Avx512F           | 128KB        |   209,545.2 ns |    317.48 ns |    281.44 ns |     112 B |
| ComputeHash | SHAKE128 | Shake128_Managed_Avx2              | 128KB        |   233,922.7 ns |    649.28 ns |    575.57 ns |     112 B |
| ComputeHash | SHAKE128 | BouncyCastle                       | 128KB        |   238,573.6 ns |  1,023.58 ns |    957.46 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHAKE256 | Shake256_Managed_Scalar            | 128B         |       280.4 ns |      3.55 ns |      3.32 ns |     176 B |
| ComputeHash | SHAKE256 | Shake256_Managed_Ssse3             | 128B         |       325.6 ns |      4.15 ns |      3.89 ns |     176 B |
| ComputeHash | SHAKE256 | Shake256_Managed_Avx512F           | 128B         |       349.7 ns |      1.75 ns |      1.55 ns |     176 B |
| ComputeHash | SHAKE256 | Shake256_Managed_Avx2              | 128B         |       359.4 ns |      0.79 ns |      0.74 ns |     176 B |
| ComputeHash | SHAKE256 | BouncyCastle                       | 128B         |       365.5 ns |      2.87 ns |      2.69 ns |     176 B |
| ComputeHash | SHAKE256 | OS Native                          | 128B         |       399.0 ns |      2.01 ns |      1.88 ns |     176 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHAKE256 | Shake256_Managed_Scalar            | 137B         |       537.8 ns |      8.48 ns |      7.93 ns |     176 B |
| ComputeHash | SHAKE256 | Shake256_Managed_Ssse3             | 137B         |       606.1 ns |      5.71 ns |      5.06 ns |     176 B |
| ComputeHash | SHAKE256 | OS Native                          | 137B         |       621.9 ns |      4.22 ns |      3.95 ns |     176 B |
| ComputeHash | SHAKE256 | BouncyCastle                       | 137B         |       669.8 ns |     10.55 ns |      9.87 ns |     176 B |
| ComputeHash | SHAKE256 | Shake256_Managed_Avx512F           | 137B         |       673.4 ns |     12.62 ns |     11.80 ns |     176 B |
| ComputeHash | SHAKE256 | Shake256_Managed_Avx2              | 137B         |       700.6 ns |     11.46 ns |     10.72 ns |     176 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHAKE256 | Shake256_Managed_Scalar            | 1KB          |     1,768.5 ns |     23.53 ns |     22.01 ns |     176 B |
| ComputeHash | SHAKE256 | OS Native                          | 1KB          |     2,043.6 ns |     11.04 ns |     10.33 ns |     176 B |
| ComputeHash | SHAKE256 | Shake256_Managed_Ssse3             | 1KB          |     2,106.5 ns |     41.47 ns |     55.36 ns |     176 B |
| ComputeHash | SHAKE256 | Shake256_Managed_Avx512F           | 1KB          |     2,261.0 ns |     30.39 ns |     28.42 ns |     176 B |
| ComputeHash | SHAKE256 | BouncyCastle                       | 1KB          |     2,550.9 ns |     50.03 ns |     46.80 ns |     176 B |
| ComputeHash | SHAKE256 | Shake256_Managed_Avx2              | 1KB          |     2,556.8 ns |     50.27 ns |     53.79 ns |     176 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHAKE256 | Shake256_Managed_Scalar            | 1025B        |     1,756.0 ns |     34.66 ns |     39.92 ns |     176 B |
| ComputeHash | SHAKE256 | OS Native                          | 1025B        |     2,065.2 ns |     26.65 ns |     23.62 ns |     176 B |
| ComputeHash | SHAKE256 | Shake256_Managed_Ssse3             | 1025B        |     2,125.8 ns |     41.64 ns |     55.59 ns |     176 B |
| ComputeHash | SHAKE256 | Shake256_Managed_Avx512F           | 1025B        |     2,268.6 ns |     24.24 ns |     21.49 ns |     176 B |
| ComputeHash | SHAKE256 | Shake256_Managed_Avx2              | 1025B        |     2,506.1 ns |     16.84 ns |     14.93 ns |     176 B |
| ComputeHash | SHAKE256 | BouncyCastle                       | 1025B        |     2,567.4 ns |     46.28 ns |     43.29 ns |     176 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHAKE256 | Shake256_Managed_Scalar            | 8KB          |    12,626.4 ns |    135.96 ns |    113.53 ns |     176 B |
| ComputeHash | SHAKE256 | OS Native                          | 8KB          |    14,757.6 ns |    220.28 ns |    183.94 ns |     176 B |
| ComputeHash | SHAKE256 | Shake256_Managed_Ssse3             | 8KB          |    15,034.8 ns |    224.63 ns |    199.13 ns |     176 B |
| ComputeHash | SHAKE256 | Shake256_Managed_Avx512F           | 8KB          |    16,443.3 ns |     62.31 ns |     55.23 ns |     176 B |
| ComputeHash | SHAKE256 | Shake256_Managed_Avx2              | 8KB          |    18,462.9 ns |     76.36 ns |     71.43 ns |     176 B |
| ComputeHash | SHAKE256 | BouncyCastle                       | 8KB          |    19,121.2 ns |    326.14 ns |    305.07 ns |     176 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SHAKE256 | Shake256_Managed_Scalar            | 128KB        |   197,902.4 ns |  2,834.04 ns |  2,650.97 ns |     176 B |
| ComputeHash | SHAKE256 | OS Native                          | 128KB        |   230,561.6 ns |  2,837.44 ns |  2,654.14 ns |     176 B |
| ComputeHash | SHAKE256 | Shake256_Managed_Ssse3             | 128KB        |   237,095.9 ns |  4,193.10 ns |  3,922.23 ns |     176 B |
| ComputeHash | SHAKE256 | Shake256_Managed_Avx512F           | 128KB        |   263,648.4 ns |  4,361.19 ns |  6,254.69 ns |     176 B |
| ComputeHash | SHAKE256 | Shake256_Managed_Avx2              | 128KB        |   292,632.4 ns |  4,920.95 ns |  4,603.06 ns |     176 B |
| ComputeHash | SHAKE256 | BouncyCastle                       | 128KB        |   298,648.8 ns |  3,287.73 ns |  3,075.34 ns |     176 B |
|                                                             |              |                |              |              |           |
| ComputeHash | SM3 | BouncyCastle                            | 128B         |       828.4 ns |      9.14 ns |      8.55 ns |     112 B |
| **ComputeHash | SM3 | CryptoHives**                             | **128B**         |       **957.3 ns** |     **11.53 ns** |     **10.22 ns** |     **112 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SM3 | BouncyCastle**                            | **137B**         |       **831.6 ns** |      **7.71 ns** |      **6.83 ns** |     **112 B** |
| **ComputeHash | SM3 | CryptoHives**                             | **137B**         |       **953.5 ns** |      **4.07 ns** |      **3.60 ns** |     **112 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SM3 | BouncyCastle**                            | **1KB**          |     **4,424.8 ns** |     **38.00 ns** |     **35.55 ns** |     **112 B** |
| **ComputeHash | SM3 | CryptoHives**                             | **1KB**          |     **5,307.8 ns** |     **95.91 ns** |     **89.71 ns** |     **112 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SM3 | BouncyCastle**                            | **1025B**        |     **4,479.5 ns** |     **66.06 ns** |     **61.80 ns** |     **112 B** |
| **ComputeHash | SM3 | CryptoHives**                             | **1025B**        |     **5,240.3 ns** |     **53.00 ns** |     **46.98 ns** |     **112 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SM3 | BouncyCastle**                            | **8KB**          |    **33,974.0 ns** |    **671.23 ns** |    **718.21 ns** |     **112 B** |
| **ComputeHash | SM3 | CryptoHives**                             | **8KB**          |    **40,413.3 ns** |    **800.17 ns** |    **709.33 ns** |     **112 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | SM3 | BouncyCastle**                            | **128KB**        |   **537,685.0 ns** |  **5,015.73 ns** |  **4,446.31 ns** |     **112 B** |
| **ComputeHash | SM3 | CryptoHives**                             | **128KB**        |   **624,401.1 ns** |  **1,587.10 ns** |  **1,484.58 ns** |     **112 B** |
|                                                             |              |                |              |              |           |
| ComputeHash | Streebog-256 | CryptoHives                    | 128B         |     2,462.2 ns |     15.50 ns |     13.74 ns |     112 B |
| **ComputeHash | Streebog-256 | OpenGost**                       | **128B**         |     **3,548.0 ns** |     **40.77 ns** |     **36.14 ns** |     **464 B** |
| ComputeHash | Streebog-256 | BouncyCastle                   | 128B         |     4,417.9 ns |     44.96 ns |     42.05 ns |     200 B |
|                                                             |              |                |              |              |           |
| **ComputeHash | Streebog-256 | CryptoHives**                    | **137B**         |     **2,464.4 ns** |     **20.43 ns** |     **17.06 ns** |     **112 B** |
| **ComputeHash | Streebog-256 | OpenGost**                       | **137B**         |     **3,545.1 ns** |     **27.62 ns** |     **25.84 ns** |     **464 B** |
| ComputeHash | Streebog-256 | BouncyCastle                   | 137B         |     4,428.3 ns |     44.44 ns |     39.40 ns |     200 B |
|                                                             |              |                |              |              |           |
| **ComputeHash | Streebog-256 | CryptoHives**                    | **1KB**          |     **9,252.0 ns** |     **50.85 ns** |     **45.08 ns** |     **112 B** |
| **ComputeHash | Streebog-256 | OpenGost**                       | **1KB**          |    **13,127.4 ns** |    **137.52 ns** |    **128.64 ns** |     **464 B** |
| ComputeHash | Streebog-256 | BouncyCastle                   | 1KB          |    16,625.0 ns |    179.41 ns |    149.82 ns |     200 B |
|                                                             |              |                |              |              |           |
| **ComputeHash | Streebog-256 | CryptoHives**                    | **1025B**        |     **8,974.4 ns** |     **22.61 ns** |     **20.04 ns** |     **112 B** |
| **ComputeHash | Streebog-256 | OpenGost**                       | **1025B**        |    **13,107.4 ns** |    **136.42 ns** |    **120.94 ns** |     **464 B** |
| ComputeHash | Streebog-256 | BouncyCastle                   | 1025B        |    16,571.4 ns |    137.59 ns |    121.97 ns |     200 B |
|                                                             |              |                |              |              |           |
| **ComputeHash | Streebog-256 | CryptoHives**                    | **8KB**          |    **63,139.7 ns** |    **375.32 ns** |    **293.02 ns** |     **112 B** |
| **ComputeHash | Streebog-256 | OpenGost**                       | **8KB**          |    **89,692.7 ns** |    **669.73 ns** |    **626.46 ns** |     **464 B** |
| ComputeHash | Streebog-256 | BouncyCastle                   | 8KB          |   115,805.9 ns |    695.55 ns |    650.62 ns |     200 B |
|                                                             |              |                |              |              |           |
| **ComputeHash | Streebog-256 | CryptoHives**                    | **128KB**        |   **976,108.6 ns** |    **946.72 ns** |    **739.14 ns** |     **112 B** |
| **ComputeHash | Streebog-256 | OpenGost**                       | **128KB**        | **1,386,755.8 ns** |  **4,299.86 ns** |  **3,590.58 ns** |     **464 B** |
| ComputeHash | Streebog-256 | BouncyCastle                   | 128KB        | 1,802,654.3 ns |  2,738.47 ns |  2,138.02 ns |     200 B |
|                                                             |              |                |              |              |           |
| **ComputeHash | Streebog-512 | CryptoHives**                    | **128B**         |     **2,478.7 ns** |     **10.51 ns** |      **9.32 ns** |     **176 B** |
| **ComputeHash | Streebog-512 | OpenGost**                       | **128B**         |     **3,477.4 ns** |     **24.85 ns** |     **23.24 ns** |     **264 B** |
| ComputeHash | Streebog-512 | BouncyCastle                   | 128B         |     4,383.1 ns |     43.58 ns |     38.63 ns |     176 B |
|                                                             |              |                |              |              |           |
| **ComputeHash | Streebog-512 | CryptoHives**                    | **137B**         |     **2,432.7 ns** |     **11.64 ns** |     **10.32 ns** |     **176 B** |
| **ComputeHash | Streebog-512 | OpenGost**                       | **137B**         |     **3,447.7 ns** |     **13.94 ns** |     **11.64 ns** |     **264 B** |
| ComputeHash | Streebog-512 | BouncyCastle                   | 137B         |     4,440.3 ns |     39.47 ns |     34.99 ns |     176 B |
|                                                             |              |                |              |              |           |
| **ComputeHash | Streebog-512 | CryptoHives**                    | **1KB**          |     **9,405.4 ns** |     **43.22 ns** |     **36.09 ns** |     **176 B** |
| **ComputeHash | Streebog-512 | OpenGost**                       | **1KB**          |    **13,092.3 ns** |    **132.28 ns** |    **110.46 ns** |     **264 B** |
| ComputeHash | Streebog-512 | BouncyCastle                   | 1KB          |    16,782.1 ns |    166.65 ns |    155.88 ns |     176 B |
|                                                             |              |                |              |              |           |
| **ComputeHash | Streebog-512 | CryptoHives**                    | **1025B**        |     **9,481.7 ns** |     **43.97 ns** |     **38.98 ns** |     **176 B** |
| **ComputeHash | Streebog-512 | OpenGost**                       | **1025B**        |    **13,091.0 ns** |     **91.87 ns** |     **85.94 ns** |     **264 B** |
| ComputeHash | Streebog-512 | BouncyCastle                   | 1025B        |    16,658.4 ns |    164.32 ns |    145.66 ns |     176 B |
|                                                             |              |                |              |              |           |
| **ComputeHash | Streebog-512 | CryptoHives**                    | **8KB**          |    **63,220.7 ns** |    **295.82 ns** |    **276.71 ns** |     **176 B** |
| **ComputeHash | Streebog-512 | OpenGost**                       | **8KB**          |    **89,218.2 ns** |  **1,349.16 ns** |  **1,195.99 ns** |     **264 B** |
| ComputeHash | Streebog-512 | BouncyCastle                   | 8KB          |   116,222.5 ns |  1,101.25 ns |  1,030.11 ns |     176 B |
|                                                             |              |                |              |              |           |
| **ComputeHash | Streebog-512 | CryptoHives**                    | **128KB**        |   **942,017.4 ns** |  **6,892.16 ns** |  **5,755.26 ns** |     **176 B** |
| **ComputeHash | Streebog-512 | OpenGost**                       | **128KB**        | **1,394,208.0 ns** | **15,439.37 ns** | **14,441.99 ns** |     **264 B** |
| ComputeHash | Streebog-512 | BouncyCastle                   | 128KB        | 1,918,734.3 ns | 16,165.39 ns | 15,121.12 ns |     176 B |
|                                                             |              |                |              |              |           |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Scalar  | 128B         |       184.6 ns |      0.51 ns |      0.47 ns |     112 B |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Ssse3   | 128B         |       205.6 ns |      0.60 ns |      0.54 ns |     112 B |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Avx512F | 128B         |       207.9 ns |      1.09 ns |      1.02 ns |     112 B |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Avx2    | 128B         |       225.9 ns |      1.60 ns |      1.50 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Scalar  | 137B         |       181.9 ns |      0.72 ns |      0.60 ns |     112 B |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Avx512F | 137B         |       201.7 ns |      0.32 ns |      0.29 ns |     112 B |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Ssse3   | 137B         |       220.6 ns |      2.23 ns |      2.08 ns |     112 B |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Avx2    | 137B         |       222.0 ns |      0.60 ns |      0.50 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Scalar  | 1KB          |       893.3 ns |      3.20 ns |      2.84 ns |     112 B |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Ssse3   | 1KB          |     1,052.6 ns |     15.89 ns |     14.08 ns |     112 B |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Avx512F | 1KB          |     1,116.3 ns |     10.53 ns |      9.33 ns |     112 B |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Avx2    | 1KB          |     1,178.5 ns |     18.38 ns |     16.30 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Scalar  | 1025B        |       895.0 ns |     11.72 ns |     10.39 ns |     112 B |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Ssse3   | 1025B        |     1,058.5 ns |     18.31 ns |     16.23 ns |     112 B |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Avx512F | 1025B        |     1,134.3 ns |     19.59 ns |     18.33 ns |     112 B |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Avx2    | 1025B        |     1,201.1 ns |     17.11 ns |     16.01 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Scalar  | 8KB          |     5,510.1 ns |    106.16 ns |    104.26 ns |     112 B |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Ssse3   | 8KB          |     6,692.0 ns |     30.86 ns |     27.35 ns |     112 B |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Avx512F | 8KB          |     7,055.1 ns |     57.90 ns |     51.33 ns |     112 B |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Avx2    | 8KB          |     7,899.5 ns |    157.76 ns |    147.57 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Scalar  | 128KB        |    87,861.3 ns |  1,112.40 ns |    986.11 ns |     112 B |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Ssse3   | 128KB        |   106,744.4 ns |  1,704.69 ns |  1,594.57 ns |     112 B |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Avx512F | 128KB        |   111,225.0 ns |  1,211.42 ns |  1,011.59 ns |     112 B |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Avx2    | 128KB        |   126,146.2 ns |  2,479.04 ns |  2,854.87 ns |     112 B |
|                                                             |              |                |              |              |           |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Scalar  | 128B         |       197.2 ns |      3.90 ns |      4.65 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Avx512F | 128B         |       219.7 ns |      3.83 ns |      3.58 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Ssse3   | 128B         |       224.5 ns |      4.50 ns |      4.63 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Avx2    | 128B         |       231.8 ns |      2.15 ns |      1.90 ns |     176 B |
|                                                             |              |                |              |              |           |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Scalar  | 137B         |       359.6 ns |      6.54 ns |      5.79 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Ssse3   | 137B         |       403.0 ns |      7.77 ns |      8.64 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Avx512F | 137B         |       407.8 ns |      8.16 ns |      9.71 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Avx2    | 137B         |       431.8 ns |      8.53 ns |      8.76 ns |     176 B |
|                                                             |              |                |              |              |           |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Scalar  | 1KB          |       994.9 ns |     19.74 ns |     27.01 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Ssse3   | 1KB          |     1,168.9 ns |     21.74 ns |     18.15 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Avx512F | 1KB          |     1,261.7 ns |     25.14 ns |     29.92 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Avx2    | 1KB          |     1,388.4 ns |     27.12 ns |     30.14 ns |     176 B |
|                                                             |              |                |              |              |           |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Scalar  | 1025B        |     1,011.1 ns |     19.55 ns |     26.76 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Ssse3   | 1025B        |     1,173.5 ns |     23.43 ns |     20.77 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Avx512F | 1025B        |     1,254.2 ns |     16.48 ns |     13.76 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Avx2    | 1025B        |     1,386.6 ns |     26.26 ns |     24.56 ns |     176 B |
|                                                             |              |                |              |              |           |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Scalar  | 8KB          |     6,987.4 ns |    125.55 ns |    117.44 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Ssse3   | 8KB          |     8,239.4 ns |    159.76 ns |    202.04 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Avx512F | 8KB          |     8,760.4 ns |    111.04 ns |     98.43 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Avx2    | 8KB          |     9,858.5 ns |    195.93 ns |    225.63 ns |     176 B |
|                                                             |              |                |              |              |           |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Scalar  | 128KB        |   108,839.1 ns |  2,053.56 ns |  2,444.61 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Ssse3   | 128KB        |   129,718.8 ns |  2,544.67 ns |  3,885.98 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Avx512F | 128KB        |   138,671.8 ns |  2,683.19 ns |  2,870.98 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Avx2    | 128KB        |   154,686.2 ns |  3,035.40 ns |  3,373.84 ns |     176 B |
|                                                             |              |                |              |              |           |
| **ComputeHash | Whirlpool | CryptoHives**                       | **128B**         |     **1,456.8 ns** |     **18.21 ns** |     **17.04 ns** |     **176 B** |
| **ComputeHash | Whirlpool | BouncyCastle**                      | **128B**         |     **5,464.2 ns** |    **106.77 ns** |    **156.50 ns** |     **232 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | Whirlpool | CryptoHives**                       | **137B**         |     **1,434.8 ns** |     **28.10 ns** |     **27.60 ns** |     **176 B** |
| **ComputeHash | Whirlpool | BouncyCastle**                      | **137B**         |     **5,348.0 ns** |    **104.35 ns** |    **165.51 ns** |     **232 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | Whirlpool | CryptoHives**                       | **1KB**          |     **7,886.1 ns** |    **145.41 ns** |    **155.59 ns** |     **176 B** |
| **ComputeHash | Whirlpool | BouncyCastle**                      | **1KB**          |    **31,877.3 ns** |    **498.19 ns** |    **416.01 ns** |     **232 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | Whirlpool | CryptoHives**                       | **1025B**        |     **7,856.8 ns** |    **142.78 ns** |    **133.55 ns** |     **176 B** |
| **ComputeHash | Whirlpool | BouncyCastle**                      | **1025B**        |    **31,929.0 ns** |    **630.80 ns** |    **619.53 ns** |     **232 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | Whirlpool | CryptoHives**                       | **8KB**          |    **59,618.2 ns** |  **1,150.90 ns** |  **1,076.55 ns** |     **176 B** |
| **ComputeHash | Whirlpool | BouncyCastle**                      | **8KB**          |   **249,750.0 ns** |  **1,627.37 ns** |  **1,442.62 ns** |     **232 B** |
|                                                             |              |                |              |              |           |
| **ComputeHash | Whirlpool | CryptoHives**                       | **128KB**        |   **948,635.7 ns** |  **3,626.31 ns** |  **3,392.05 ns** |     **176 B** |
| **ComputeHash | Whirlpool | BouncyCastle**                      | **128KB**        | **3,930,019.1 ns** | **12,900.06 ns** | **12,066.72 ns** |     **232 B** |
