```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26100.7623/24H2/2024Update/HudsonValley)
AMD Ryzen 5 7600X 4.70GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 10.0.102
  [Host]    : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v4
  .NET 10.0 : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v4

Method=ComputeHash  Job=.NET 10.0  Runtime=.NET 10.0  
Toolchain=net10.0  

```
| Description                                                 | TestDataSize | Mean           | Error        | StdDev       | Median         | Allocated |
|------------------------------------------------------------ |------------- |---------------:|-------------:|-------------:|---------------:|----------:|
| **ComputeHash | BLAKE2b-512 | BouncyCastle**                    | **128B**         |       **130.8 ns** |      **2.21 ns** |      **2.07 ns** |       **130.2 ns** |     **176 B** |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Avx2            | 128B         |       142.4 ns |      1.71 ns |      1.43 ns |       142.1 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Scalar          | 128B         |       400.9 ns |      7.51 ns |      7.02 ns |       396.2 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | BLAKE2b-512 | BouncyCastle                    | 137B         |       207.9 ns |      1.29 ns |      1.01 ns |       207.8 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Avx2            | 137B         |       248.6 ns |      3.08 ns |      2.73 ns |       247.6 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Scalar          | 137B         |       759.5 ns |     12.07 ns |     11.29 ns |       759.8 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | BLAKE2b-512 | BouncyCastle                    | 1KB          |       737.3 ns |      1.23 ns |      1.02 ns |       737.0 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Avx2            | 1KB          |       866.3 ns |      8.62 ns |      9.93 ns |       861.2 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Scalar          | 1KB          |     2,900.9 ns |     44.18 ns |     41.32 ns |     2,888.2 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | BLAKE2b-512 | BouncyCastle                    | 1025B        |       966.5 ns |     18.92 ns |     23.23 ns |       962.9 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Avx2            | 1025B        |     1,002.4 ns |     19.94 ns |     28.59 ns |     1,001.2 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Scalar          | 1025B        |     3,334.0 ns |     63.99 ns |     85.43 ns |     3,330.1 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | BLAKE2b-512 | BouncyCastle                    | 8KB          |     5,680.0 ns |     64.98 ns |    117.17 ns |     5,612.3 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Avx2            | 8KB          |     7,156.4 ns |    194.45 ns |    573.35 ns |     6,917.1 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Scalar          | 8KB          |    23,359.3 ns |    366.07 ns |    342.43 ns |    23,331.5 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | BLAKE2b-512 | BouncyCastle                    | 128KB        |    89,443.9 ns |  1,471.37 ns |  1,304.33 ns |    89,033.3 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Avx2            | 128KB        |   112,228.6 ns |  1,692.38 ns |  1,583.05 ns |   111,484.7 ns |     176 B |
| ComputeHash | BLAKE2b-512 | Blake2b_Managed_Scalar          | 128KB        |   365,719.3 ns |  5,872.03 ns |  5,492.70 ns |   364,818.0 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | BLAKE2s-256 | BouncyCastle                    | 128B         |       191.2 ns |      3.41 ns |      3.19 ns |       189.6 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Avx2            | 128B         |       191.3 ns |      2.93 ns |      2.74 ns |       190.4 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Sse2            | 128B         |       211.8 ns |      3.72 ns |      3.48 ns |       210.6 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Scalar          | 128B         |       619.1 ns |      1.88 ns |      1.47 ns |       619.2 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | BLAKE2s-256 | BouncyCastle                    | 137B         |       264.3 ns |      4.09 ns |      3.83 ns |       262.3 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Avx2            | 137B         |       269.8 ns |      1.81 ns |      1.41 ns |       269.8 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Sse2            | 137B         |       305.2 ns |      5.52 ns |      5.17 ns |       303.3 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Scalar          | 137B         |       910.3 ns |      3.52 ns |      2.75 ns |       909.9 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Avx2            | 1KB          |     1,259.1 ns |     18.34 ns |     17.15 ns |     1,254.6 ns |     112 B |
| ComputeHash | BLAKE2s-256 | BouncyCastle                    | 1KB          |     1,261.1 ns |     16.16 ns |     18.62 ns |     1,253.5 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Sse2            | 1KB          |     1,435.5 ns |     18.16 ns |     16.99 ns |     1,429.4 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Scalar          | 1KB          |     4,719.3 ns |     57.79 ns |     54.05 ns |     4,705.5 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Avx2            | 1025B        |     1,333.9 ns |     20.23 ns |     18.92 ns |     1,323.7 ns |     112 B |
| ComputeHash | BLAKE2s-256 | BouncyCastle                    | 1025B        |     1,342.2 ns |     22.86 ns |     21.38 ns |     1,330.2 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Sse2            | 1025B        |     1,532.4 ns |     24.74 ns |     23.14 ns |     1,519.9 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Scalar          | 1025B        |     5,017.7 ns |     78.61 ns |     73.53 ns |     4,990.0 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Avx2            | 8KB          |     9,684.6 ns |     81.25 ns |     63.43 ns |     9,679.7 ns |     112 B |
| ComputeHash | BLAKE2s-256 | BouncyCastle                    | 8KB          |     9,709.6 ns |    147.82 ns |    131.04 ns |     9,651.4 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Sse2            | 8KB          |    11,211.1 ns |    174.63 ns |    163.35 ns |    11,160.9 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Scalar          | 8KB          |    37,117.6 ns |    151.20 ns |    118.05 ns |    37,084.8 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | BLAKE2s-256 | BouncyCastle                    | 128KB        |   153,971.2 ns |  1,045.72 ns |    816.43 ns |   153,763.4 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Avx2            | 128KB        |   156,601.0 ns |  2,842.13 ns |  2,658.53 ns |   155,194.9 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Sse2            | 128KB        |   177,610.1 ns |  1,299.22 ns |  1,014.34 ns |   177,873.6 ns |     112 B |
| ComputeHash | BLAKE2s-256 | Blake2s_Managed_Scalar          | 128KB        |   601,429.9 ns |  9,126.94 ns |  8,537.35 ns |   599,139.3 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | BLAKE3 | Native                               | 128B         |       114.1 ns |      0.44 ns |      0.41 ns |       114.1 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Ssse3                 | 128B         |       391.2 ns |      6.53 ns |      6.11 ns |       388.1 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Scalar                | 128B         |       575.0 ns |      1.43 ns |      1.34 ns |       575.3 ns |     112 B |
| ComputeHash | BLAKE3 | BouncyCastle                         | 128B         |     1,252.5 ns |      2.11 ns |      1.97 ns |     1,252.3 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | BLAKE3 | Native                               | 137B         |       159.2 ns |      0.25 ns |      0.24 ns |       159.2 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Ssse3                 | 137B         |       444.8 ns |      0.93 ns |      0.83 ns |       444.8 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Scalar                | 137B         |       834.8 ns |      2.45 ns |      2.17 ns |       834.4 ns |     112 B |
| ComputeHash | BLAKE3 | BouncyCastle                         | 137B         |     1,884.7 ns |      2.43 ns |      2.15 ns |     1,884.4 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | BLAKE3 | Native                               | 1KB          |       758.5 ns |      1.39 ns |      1.16 ns |       758.7 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Ssse3                 | 1KB          |     1,300.8 ns |      1.51 ns |      1.41 ns |     1,300.9 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Scalar                | 1KB          |     4,208.5 ns |     11.87 ns |     11.11 ns |     4,209.0 ns |     112 B |
| ComputeHash | BLAKE3 | BouncyCastle                         | 1KB          |     9,275.1 ns |     17.54 ns |     14.65 ns |     9,269.0 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | BLAKE3 | Native                               | 1025B        |       860.7 ns |      1.19 ns |      1.11 ns |       860.5 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Ssse3                 | 1025B        |     1,445.3 ns |      2.35 ns |      2.20 ns |     1,445.6 ns |     224 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Scalar                | 1025B        |     4,771.6 ns |     12.33 ns |     11.53 ns |     4,771.0 ns |     224 B |
| ComputeHash | BLAKE3 | BouncyCastle                         | 1025B        |    10,908.3 ns |     18.83 ns |     16.69 ns |    10,910.4 ns |     168 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | BLAKE3 | Native                               | 8KB          |     1,181.0 ns |      3.34 ns |      2.96 ns |     1,181.1 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Ssse3                 | 8KB          |    10,330.2 ns |     14.68 ns |     13.73 ns |    10,327.5 ns |     896 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Scalar                | 8KB          |    35,367.1 ns |     59.17 ns |     52.45 ns |    35,344.9 ns |     896 B |
| ComputeHash | BLAKE3 | BouncyCastle                         | 8KB          |    78,906.2 ns |    159.88 ns |    149.55 ns |    78,874.7 ns |     504 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | BLAKE3 | Native                               | 128KB        |    14,198.9 ns |     30.45 ns |     26.99 ns |    14,196.5 ns |     112 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Ssse3                 | 128KB        |   168,598.4 ns |    257.59 ns |    228.35 ns |   168,642.2 ns |   14336 B |
| ComputeHash | BLAKE3 | Blake3_Managed_Scalar                | 128KB        |   569,278.0 ns |  1,275.74 ns |  1,193.32 ns |   568,754.8 ns |   14336 B |
| ComputeHash | BLAKE3 | BouncyCastle                         | 128KB        | 1,267,529.7 ns |  2,534.96 ns |  2,371.20 ns | 1,267,619.3 ns |    7224 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | CSHAKE128 | CShake128_Managed_Scalar          | 128B         |       270.9 ns |      0.87 ns |      0.82 ns |       270.8 ns |     112 B |
| ComputeHash | CSHAKE128 | CShake128_Managed_Avx512F         | 128B         |       344.1 ns |      0.73 ns |      0.68 ns |       344.1 ns |     112 B |
| ComputeHash | CSHAKE128 | BouncyCastle                      | 128B         |       360.0 ns |      1.38 ns |      1.29 ns |       360.6 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | CSHAKE128 | CShake128_Managed_Scalar          | 137B         |       266.8 ns |      0.95 ns |      0.89 ns |       266.9 ns |     112 B |
| ComputeHash | CSHAKE128 | CShake128_Managed_Avx512F         | 137B         |       344.6 ns |      1.03 ns |      0.96 ns |       344.8 ns |     112 B |
| ComputeHash | CSHAKE128 | BouncyCastle                      | 137B         |       358.3 ns |      1.11 ns |      1.04 ns |       358.3 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | CSHAKE128 | CShake128_Managed_Scalar          | 1KB          |     1,516.3 ns |      6.13 ns |      5.73 ns |     1,515.8 ns |     112 B |
| ComputeHash | CSHAKE128 | CShake128_Managed_Avx512F         | 1KB          |     2,056.0 ns |      6.63 ns |      6.20 ns |     2,055.4 ns |     112 B |
| ComputeHash | CSHAKE128 | BouncyCastle                      | 1KB          |     2,185.9 ns |      4.71 ns |      4.18 ns |     2,186.0 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | CSHAKE128 | CShake128_Managed_Scalar          | 1025B        |     1,513.8 ns |      6.85 ns |      6.41 ns |     1,513.6 ns |     112 B |
| ComputeHash | CSHAKE128 | CShake128_Managed_Avx512F         | 1025B        |     2,060.4 ns |     10.61 ns |      8.86 ns |     2,060.0 ns |     112 B |
| ComputeHash | CSHAKE128 | BouncyCastle                      | 1025B        |     2,189.5 ns |      6.54 ns |      5.80 ns |     2,189.2 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | CSHAKE128 | CShake128_Managed_Scalar          | 8KB          |    10,060.1 ns |     36.82 ns |     34.44 ns |    10,059.0 ns |     112 B |
| ComputeHash | CSHAKE128 | CShake128_Managed_Avx512F         | 8KB          |    13,697.1 ns |     23.68 ns |     20.99 ns |    13,697.4 ns |     112 B |
| ComputeHash | CSHAKE128 | BouncyCastle                      | 8KB          |    14,997.9 ns |     30.09 ns |     26.67 ns |    14,998.9 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | CSHAKE128 | CShake128_Managed_Scalar          | 128KB        |   155,408.0 ns |    546.17 ns |    510.89 ns |   155,341.7 ns |     112 B |
| ComputeHash | CSHAKE128 | CShake128_Managed_Avx512F         | 128KB        |   217,487.4 ns |    553.94 ns |    491.05 ns |   217,612.6 ns |     112 B |
| ComputeHash | CSHAKE128 | BouncyCastle                      | 128KB        |   238,096.8 ns |    429.59 ns |    401.84 ns |   238,053.4 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | CSHAKE256 | CShake256_Managed_Scalar          | 128B         |       276.1 ns |      0.91 ns |      0.85 ns |       275.9 ns |     176 B |
| ComputeHash | CSHAKE256 | CShake256_Managed_Avx512F         | 128B         |       358.8 ns |      3.79 ns |      3.55 ns |       359.7 ns |     176 B |
| ComputeHash | CSHAKE256 | BouncyCastle                      | 128B         |       360.9 ns |      0.89 ns |      0.78 ns |       361.1 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | CSHAKE256 | CShake256_Managed_Scalar          | 137B         |       521.4 ns |      1.84 ns |      1.73 ns |       521.7 ns |     176 B |
| ComputeHash | CSHAKE256 | BouncyCastle                      | 137B         |       668.7 ns |      2.02 ns |      1.89 ns |       669.2 ns |     176 B |
| ComputeHash | CSHAKE256 | CShake256_Managed_Avx512F         | 137B         |       678.5 ns |      1.31 ns |      1.16 ns |       678.9 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | CSHAKE256 | CShake256_Managed_Scalar          | 1KB          |     1,694.3 ns |      4.12 ns |      3.65 ns |     1,693.6 ns |     176 B |
| ComputeHash | CSHAKE256 | CShake256_Managed_Avx512F         | 1KB          |     2,314.1 ns |      3.91 ns |      3.47 ns |     2,313.7 ns |     176 B |
| ComputeHash | CSHAKE256 | BouncyCastle                      | 1KB          |     2,476.5 ns |      8.53 ns |      7.98 ns |     2,475.9 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | CSHAKE256 | CShake256_Managed_Scalar          | 1025B        |     1,685.1 ns |      5.39 ns |      5.04 ns |     1,685.0 ns |     176 B |
| ComputeHash | CSHAKE256 | CShake256_Managed_Avx512F         | 1025B        |     2,315.8 ns |      5.10 ns |      4.77 ns |     2,314.2 ns |     176 B |
| ComputeHash | CSHAKE256 | BouncyCastle                      | 1025B        |     2,475.1 ns |      4.35 ns |      4.06 ns |     2,476.0 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | CSHAKE256 | CShake256_Managed_Scalar          | 8KB          |    12,184.4 ns |     32.39 ns |     28.71 ns |    12,173.5 ns |     176 B |
| ComputeHash | CSHAKE256 | CShake256_Managed_Avx512F         | 8KB          |    17,018.4 ns |     31.88 ns |     28.26 ns |    17,015.0 ns |     176 B |
| ComputeHash | CSHAKE256 | BouncyCastle                      | 8KB          |    18,487.2 ns |     61.24 ns |     54.29 ns |    18,502.6 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | CSHAKE256 | CShake256_Managed_Scalar          | 128KB        |   191,052.3 ns |    799.13 ns |    747.51 ns |   190,980.1 ns |     176 B |
| ComputeHash | CSHAKE256 | CShake256_Managed_Avx512F         | 128KB        |   266,876.0 ns |    982.78 ns |    820.66 ns |   266,832.6 ns |     176 B |
| ComputeHash | CSHAKE256 | BouncyCastle                      | 128KB        |   290,960.6 ns |    761.67 ns |    675.20 ns |   291,222.1 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | Keccak-256 | Keccak256_Managed_Scalar         | 128B         |       239.3 ns |      1.14 ns |      1.07 ns |       239.0 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx512F        | 128B         |       313.1 ns |      0.64 ns |      0.57 ns |       313.1 ns |     112 B |
| ComputeHash | Keccak-256 | BouncyCastle                     | 128B         |       356.2 ns |      0.81 ns |      0.76 ns |       356.2 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | Keccak-256 | Keccak256_Managed_Scalar         | 137B         |       479.7 ns |      2.55 ns |      2.26 ns |       479.2 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx512F        | 137B         |       635.6 ns |      1.05 ns |      0.98 ns |       635.7 ns |     112 B |
| ComputeHash | Keccak-256 | BouncyCastle                     | 137B         |       647.2 ns |      2.17 ns |      2.03 ns |       646.7 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | Keccak-256 | Keccak256_Managed_Scalar         | 1KB          |     1,646.8 ns |      2.49 ns |      2.08 ns |     1,646.5 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx512F        | 1KB          |     2,273.6 ns |      6.44 ns |      5.02 ns |     2,272.0 ns |     112 B |
| ComputeHash | Keccak-256 | BouncyCastle                     | 1KB          |     2,465.3 ns |      5.26 ns |      4.40 ns |     2,465.9 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | Keccak-256 | Keccak256_Managed_Scalar         | 1025B        |     2,130.3 ns |      9.83 ns |      7.68 ns |     2,128.8 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx512F        | 1025B        |     2,280.7 ns |      3.61 ns |      3.02 ns |     2,280.3 ns |     112 B |
| ComputeHash | Keccak-256 | BouncyCastle                     | 1025B        |     2,472.7 ns |      7.63 ns |      6.77 ns |     2,472.4 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | Keccak-256 | Keccak256_Managed_Scalar         | 8KB          |    12,200.4 ns |     33.54 ns |     28.01 ns |    12,194.7 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx512F        | 8KB          |    16,945.8 ns |     19.90 ns |     16.62 ns |    16,949.4 ns |     112 B |
| ComputeHash | Keccak-256 | BouncyCastle                     | 8KB          |    18,556.7 ns |     70.07 ns |     65.55 ns |    18,560.8 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | Keccak-256 | Keccak256_Managed_Scalar         | 128KB        |   191,308.2 ns |    439.13 ns |    410.76 ns |   191,241.1 ns |     112 B |
| ComputeHash | Keccak-256 | Keccak256_Managed_Avx512F        | 128KB        |   267,463.5 ns |  1,115.85 ns |    931.79 ns |   267,206.3 ns |     112 B |
| ComputeHash | Keccak-256 | BouncyCastle                     | 128KB        |   290,164.8 ns |    688.71 ns |    575.10 ns |   290,182.7 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | KMAC-128 | CryptoHives**                        | **128B**         |       **726.1 ns** |      **2.18 ns** |      **2.04 ns** |       **726.5 ns** |     **824 B** |
| **ComputeHash | KMAC-128 | OS Native**                          | **128B**         |     **1,046.6 ns** |      **4.86 ns** |      **4.55 ns** |     **1,046.0 ns** |     **296 B** |
| ComputeHash | KMAC-128 | BouncyCastle                       | 128B         |     1,993.4 ns |      5.80 ns |      5.14 ns |     1,991.7 ns |     400 B |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | KMAC-128 | CryptoHives**                        | **137B**         |       **723.0 ns** |      **1.94 ns** |      **1.72 ns** |       **722.9 ns** |     **824 B** |
| **ComputeHash | KMAC-128 | OS Native**                          | **137B**         |     **1,052.5 ns** |      **2.90 ns** |      **2.57 ns** |     **1,051.3 ns** |     **312 B** |
| ComputeHash | KMAC-128 | BouncyCastle                       | 137B         |     1,987.4 ns |      5.94 ns |      5.56 ns |     1,987.7 ns |     400 B |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | KMAC-128 | CryptoHives**                        | **1KB**          |     **1,964.2 ns** |      **8.79 ns** |      **8.23 ns** |     **1,965.2 ns** |     **824 B** |
| **ComputeHash | KMAC-128 | OS Native**                          | **1KB**          |     **2,515.6 ns** |      **9.61 ns** |      **8.99 ns** |     **2,513.6 ns** |    **1192 B** |
| ComputeHash | KMAC-128 | BouncyCastle                       | 1KB          |     3,822.5 ns |     13.91 ns |     13.01 ns |     3,817.1 ns |     400 B |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | KMAC-128 | CryptoHives**                        | **1025B**        |     **1,966.4 ns** |      **7.91 ns** |      **7.40 ns** |     **1,969.4 ns** |     **824 B** |
| **ComputeHash | KMAC-128 | OS Native**                          | **1025B**        |     **2,561.2 ns** |      **8.25 ns** |      **7.72 ns** |     **2,562.1 ns** |    **1200 B** |
| ComputeHash | KMAC-128 | BouncyCastle                       | 1025B        |     3,809.1 ns |     13.47 ns |     12.60 ns |     3,803.7 ns |     400 B |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | KMAC-128 | CryptoHives**                        | **8KB**          |    **10,330.0 ns** |     **42.22 ns** |     **39.49 ns** |    **10,310.3 ns** |     **824 B** |
| **ComputeHash | KMAC-128 | OS Native**                          | **8KB**          |    **12,782.6 ns** |     **39.52 ns** |     **35.04 ns** |    **12,780.5 ns** |    **8360 B** |
| ComputeHash | KMAC-128 | BouncyCastle                       | 8KB          |    16,635.4 ns |     54.03 ns |     50.54 ns |    16,609.2 ns |     400 B |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | KMAC-128 | CryptoHives**                        | **128KB**        |   **156,353.7 ns** |    **684.74 ns** |    **640.51 ns** |   **156,231.6 ns** |     **824 B** |
| **ComputeHash | KMAC-128 | OS Native**                          | **128KB**        |   **221,543.0 ns** |    **951.24 ns** |    **889.79 ns** |   **221,681.0 ns** |  **131263 B** |
| ComputeHash | KMAC-128 | BouncyCastle                       | 128KB        |   239,154.8 ns |    822.78 ns |    769.62 ns |   239,473.0 ns |     400 B |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | KMAC-256 | CryptoHives**                        | **128B**         |       **729.0 ns** |      **2.24 ns** |      **2.10 ns** |       **729.3 ns** |     **824 B** |
| **ComputeHash | KMAC-256 | OS Native**                          | **128B**         |     **1,059.2 ns** |      **5.66 ns** |      **5.02 ns** |     **1,059.9 ns** |     **360 B** |
| ComputeHash | KMAC-256 | BouncyCastle                       | 128B         |     1,969.1 ns |      8.10 ns |      7.58 ns |     1,967.9 ns |     464 B |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | KMAC-256 | CryptoHives**                        | **137B**         |       **976.4 ns** |      **3.36 ns** |      **3.14 ns** |       **976.6 ns** |     **824 B** |
| **ComputeHash | KMAC-256 | OS Native**                          | **137B**         |     **1,289.0 ns** |      **4.26 ns** |      **3.78 ns** |     **1,290.0 ns** |     **376 B** |
| ComputeHash | KMAC-256 | BouncyCastle                       | 137B         |     2,256.8 ns |      8.38 ns |      7.84 ns |     2,255.7 ns |     464 B |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | KMAC-256 | CryptoHives**                        | **1KB**          |     **2,138.0 ns** |      **8.31 ns** |      **7.77 ns** |     **2,135.1 ns** |     **824 B** |
| **ComputeHash | KMAC-256 | OS Native**                          | **1KB**          |     **2,739.7 ns** |      **8.52 ns** |      **7.97 ns** |     **2,739.4 ns** |    **1256 B** |
| ComputeHash | KMAC-256 | BouncyCastle                       | 1KB          |     4,094.5 ns |      9.78 ns |      8.67 ns |     4,098.7 ns |     464 B |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | KMAC-256 | CryptoHives**                        | **1025B**        |     **2,142.0 ns** |     **10.31 ns** |      **9.14 ns** |     **2,140.1 ns** |     **824 B** |
| **ComputeHash | KMAC-256 | OS Native**                          | **1025B**        |     **2,733.2 ns** |      **8.76 ns** |      **8.19 ns** |     **2,731.9 ns** |    **1264 B** |
| ComputeHash | KMAC-256 | BouncyCastle                       | 1025B        |     4,080.6 ns |     11.40 ns |     10.10 ns |     4,081.5 ns |     464 B |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | KMAC-256 | CryptoHives**                        | **8KB**          |    **12,682.0 ns** |     **34.70 ns** |     **32.46 ns** |    **12,677.7 ns** |     **824 B** |
| **ComputeHash | KMAC-256 | OS Native**                          | **8KB**          |    **15,502.6 ns** |     **76.67 ns** |     **71.72 ns** |    **15,483.6 ns** |    **8424 B** |
| ComputeHash | KMAC-256 | BouncyCastle                       | 8KB          |    20,021.0 ns |     58.54 ns |     54.76 ns |    20,011.5 ns |     464 B |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | KMAC-256 | CryptoHives**                        | **128KB**        |   **191,518.0 ns** |    **682.92 ns** |    **605.39 ns** |   **191,618.4 ns** |     **824 B** |
| **ComputeHash | KMAC-256 | OS Native**                          | **128KB**        |   **262,982.1 ns** |  **1,429.35 ns** |  **1,337.01 ns** |   **262,954.6 ns** |  **131327 B** |
| ComputeHash | KMAC-256 | BouncyCastle                       | 128KB        |   292,304.5 ns |    711.29 ns |    665.34 ns |   292,290.6 ns |     464 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | KT128 | KT128_Managed_Scalar                  | 128B         |       224.5 ns |      1.26 ns |      1.18 ns |       224.2 ns |     584 B |
| ComputeHash | KT128 | KT128_Managed_Avx512F                 | 128B         |       253.9 ns |      0.38 ns |      0.32 ns |       254.0 ns |     584 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | KT128 | KT128_Managed_Scalar                  | 137B         |       223.3 ns |      0.54 ns |      0.51 ns |       223.4 ns |     584 B |
| ComputeHash | KT128 | KT128_Managed_Avx512F                 | 137B         |       250.2 ns |      0.69 ns |      0.64 ns |       250.0 ns |     584 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | KT128 | KT128_Managed_Scalar                  | 1KB          |       933.3 ns |      2.96 ns |      2.62 ns |       934.0 ns |     584 B |
| ComputeHash | KT128 | KT128_Managed_Avx512F                 | 1KB          |     1,186.5 ns |      3.73 ns |      3.12 ns |     1,187.9 ns |     584 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | KT128 | KT128_Managed_Scalar                  | 1025B        |       924.8 ns |      3.54 ns |      3.31 ns |       924.2 ns |     584 B |
| ComputeHash | KT128 | KT128_Managed_Avx512F                 | 1025B        |     1,183.3 ns |      3.37 ns |      3.15 ns |     1,183.2 ns |     584 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | KT128 | KT128_Managed_Scalar                  | 8KB          |     6,023.4 ns |     21.63 ns |     19.17 ns |     6,024.9 ns |    1056 B |
| ComputeHash | KT128 | KT128_Managed_Avx512F                 | 8KB          |     8,102.0 ns |     28.08 ns |     24.89 ns |     8,099.2 ns |    1056 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | KT128 | KT128_Managed_Scalar                  | 128KB        |    90,135.6 ns |    318.12 ns |    297.57 ns |    90,197.2 ns |    8136 B |
| ComputeHash | KT128 | KT128_Managed_Avx512F                 | 128KB        |   121,226.6 ns |    129.04 ns |    107.76 ns |   121,202.8 ns |    8136 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | KT256 | KT256_Managed_Scalar                  | 128B         |       223.4 ns |      0.88 ns |      0.82 ns |       223.6 ns |     616 B |
| ComputeHash | KT256 | KT256_Managed_Avx512F                 | 128B         |       256.2 ns |      0.70 ns |      0.65 ns |       256.0 ns |     616 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | KT256 | KT256_Managed_Scalar                  | 137B         |       387.0 ns |      1.31 ns |      1.23 ns |       387.2 ns |     616 B |
| ComputeHash | KT256 | KT256_Managed_Avx512F                 | 137B         |       437.3 ns |      0.88 ns |      0.82 ns |       437.4 ns |     616 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | KT256 | KT256_Managed_Scalar                  | 1KB          |     1,020.2 ns |      4.80 ns |      4.49 ns |     1,021.1 ns |     616 B |
| ComputeHash | KT256 | KT256_Managed_Avx512F                 | 1KB          |     1,325.6 ns |      5.14 ns |      4.29 ns |     1,326.2 ns |     616 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | KT256 | KT256_Managed_Scalar                  | 1025B        |     1,018.4 ns |      3.82 ns |      3.57 ns |     1,019.6 ns |     616 B |
| ComputeHash | KT256 | KT256_Managed_Avx512F                 | 1025B        |     1,327.8 ns |      3.80 ns |      3.55 ns |     1,328.8 ns |     616 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | KT256 | KT256_Managed_Scalar                  | 8KB          |     7,135.5 ns |     25.39 ns |     23.75 ns |     7,137.6 ns |    1056 B |
| ComputeHash | KT256 | KT256_Managed_Avx512F                 | 8KB          |     9,633.2 ns |     26.44 ns |     23.43 ns |     9,634.5 ns |    1056 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | KT256 | KT256_Managed_Scalar                  | 128KB        |   110,606.7 ns |    337.03 ns |    315.26 ns |   110,691.7 ns |    7656 B |
| ComputeHash | KT256 | KT256_Managed_Avx512F                 | 128KB        |   149,711.4 ns |    287.68 ns |    240.22 ns |   149,725.1 ns |    7656 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | MD5 | OS Native                               | 128B         |       292.5 ns |      0.64 ns |      0.60 ns |       292.4 ns |      80 B |
| **ComputeHash | MD5 | CryptoHives**                             | **128B**         |       **349.1 ns** |      **1.80 ns** |      **1.69 ns** |       **349.0 ns** |      **80 B** |
| **ComputeHash | MD5 | BouncyCastle**                            | **128B**         |       **393.6 ns** |      **0.79 ns** |      **0.70 ns** |       **393.5 ns** |      **80 B** |
|                                                             |              |                |              |              |                |           |
| ComputeHash | MD5 | OS Native                               | 137B         |       297.9 ns |      0.35 ns |      0.32 ns |       297.9 ns |      80 B |
| **ComputeHash | MD5 | CryptoHives**                             | **137B**         |       **351.1 ns** |      **1.22 ns** |      **1.08 ns** |       **350.9 ns** |      **80 B** |
| **ComputeHash | MD5 | BouncyCastle**                            | **137B**         |       **393.3 ns** |      **0.78 ns** |      **0.73 ns** |       **393.3 ns** |      **80 B** |
|                                                             |              |                |              |              |                |           |
| ComputeHash | MD5 | OS Native                               | 1KB          |     1,392.0 ns |      1.79 ns |      1.68 ns |     1,392.5 ns |      80 B |
| **ComputeHash | MD5 | CryptoHives**                             | **1KB**          |     **1,812.4 ns** |      **5.24 ns** |      **4.90 ns** |     **1,810.4 ns** |      **80 B** |
| **ComputeHash | MD5 | BouncyCastle**                            | **1KB**          |     **2,030.4 ns** |      **5.78 ns** |      **4.82 ns** |     **2,028.1 ns** |      **80 B** |
|                                                             |              |                |              |              |                |           |
| ComputeHash | MD5 | OS Native                               | 1025B        |     1,392.0 ns |      1.37 ns |      1.28 ns |     1,392.3 ns |      80 B |
| **ComputeHash | MD5 | CryptoHives**                             | **1025B**        |     **1,815.4 ns** |      **6.45 ns** |      **5.72 ns** |     **1,815.5 ns** |      **80 B** |
| **ComputeHash | MD5 | BouncyCastle**                            | **1025B**        |     **2,027.8 ns** |      **3.87 ns** |      **3.62 ns** |     **2,028.3 ns** |      **80 B** |
|                                                             |              |                |              |              |                |           |
| ComputeHash | MD5 | OS Native                               | 8KB          |    10,177.5 ns |      9.37 ns |      8.31 ns |    10,179.3 ns |      80 B |
| ComputeHash | MD5 | BouncyCastle                            | 8KB          |    15,001.0 ns |     21.55 ns |     19.11 ns |    15,005.4 ns |      80 B |
| **ComputeHash | MD5 | CryptoHives**                             | **8KB**          |    **18,579.1 ns** |    **367.51 ns** |    **643.67 ns** |    **18,144.5 ns** |      **80 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | MD5 | OS Native**                               | **128KB**        |   **160,800.8 ns** |    **177.82 ns** |    **157.63 ns** |   **160,793.7 ns** |      **80 B** |
| **ComputeHash | MD5 | CryptoHives**                             | **128KB**        |   **213,673.8 ns** |    **846.12 ns** |    **791.46 ns** |   **213,366.2 ns** |      **80 B** |
| **ComputeHash | MD5 | BouncyCastle**                            | **128KB**        |   **238,395.4 ns** |    **295.54 ns** |    **276.45 ns** |   **238,438.9 ns** |      **80 B** |
|                                                             |              |                |              |              |                |           |
| ComputeHash | RIPEMD-160 | BouncyCastle                     | 128B         |       667.3 ns |      2.58 ns |      2.41 ns |       666.2 ns |      96 B |
| **ComputeHash | RIPEMD-160 | CryptoHives**                      | **128B**         |       **971.2 ns** |      **4.85 ns** |      **4.05 ns** |       **972.2 ns** |      **96 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | RIPEMD-160 | BouncyCastle**                     | **137B**         |       **664.8 ns** |      **1.30 ns** |      **1.08 ns** |       **665.1 ns** |      **96 B** |
| **ComputeHash | RIPEMD-160 | CryptoHives**                      | **137B**         |       **977.2 ns** |      **7.03 ns** |      **5.49 ns** |       **976.4 ns** |      **96 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | RIPEMD-160 | BouncyCastle**                     | **1KB**          |     **3,561.1 ns** |      **5.87 ns** |      **5.50 ns** |     **3,561.7 ns** |      **96 B** |
| **ComputeHash | RIPEMD-160 | CryptoHives**                      | **1KB**          |     **5,334.4 ns** |     **57.86 ns** |     **45.17 ns** |     **5,327.6 ns** |      **96 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | RIPEMD-160 | BouncyCastle**                     | **1025B**        |     **3,544.3 ns** |      **5.36 ns** |      **5.02 ns** |     **3,543.8 ns** |      **96 B** |
| **ComputeHash | RIPEMD-160 | CryptoHives**                      | **1025B**        |     **5,323.7 ns** |     **26.41 ns** |     **20.62 ns** |     **5,319.8 ns** |      **96 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | RIPEMD-160 | BouncyCastle**                     | **8KB**          |    **26,554.9 ns** |     **61.07 ns** |     **54.14 ns** |    **26,560.4 ns** |      **96 B** |
| **ComputeHash | RIPEMD-160 | CryptoHives**                      | **8KB**          |    **41,042.6 ns** |    **248.78 ns** |    **220.54 ns** |    **40,953.6 ns** |      **96 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | RIPEMD-160 | BouncyCastle**                     | **128KB**        |   **423,567.0 ns** |    **762.69 ns** |    **713.42 ns** |   **423,592.4 ns** |      **96 B** |
| **ComputeHash | RIPEMD-160 | CryptoHives**                      | **128KB**        |   **653,356.5 ns** |  **3,285.34 ns** |  **2,564.98 ns** |   **653,260.9 ns** |      **96 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-1 | OS Native**                             | **128B**         |       **251.9 ns** |      **0.76 ns** |      **0.71 ns** |       **251.9 ns** |      **96 B** |
| ComputeHash | SHA-1 | BouncyCastle                          | 128B         |       459.4 ns |      1.31 ns |      1.23 ns |       459.2 ns |      96 B |
| **ComputeHash | SHA-1 | CryptoHives**                           | **128B**         |       **484.5 ns** |      **1.66 ns** |      **1.55 ns** |       **484.5 ns** |      **96 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-1 | OS Native**                             | **137B**         |       **252.9 ns** |      **1.04 ns** |      **0.97 ns** |       **253.1 ns** |      **96 B** |
| ComputeHash | SHA-1 | BouncyCastle                          | 137B         |       462.7 ns |      0.90 ns |      0.85 ns |       463.0 ns |      96 B |
| **ComputeHash | SHA-1 | CryptoHives**                           | **137B**         |       **480.9 ns** |      **1.50 ns** |      **1.40 ns** |       **480.9 ns** |      **96 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-1 | OS Native**                             | **1KB**          |     **1,120.7 ns** |      **3.20 ns** |      **2.99 ns** |     **1,120.8 ns** |      **96 B** |
| ComputeHash | SHA-1 | BouncyCastle                          | 1KB          |     2,456.9 ns |      6.19 ns |      5.79 ns |     2,458.1 ns |      96 B |
| **ComputeHash | SHA-1 | CryptoHives**                           | **1KB**          |     **2,474.1 ns** |      **8.91 ns** |      **7.90 ns** |     **2,472.7 ns** |      **96 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-1 | OS Native**                             | **1025B**        |     **1,122.9 ns** |      **3.43 ns** |      **3.21 ns** |     **1,123.7 ns** |      **96 B** |
| ComputeHash | SHA-1 | BouncyCastle                          | 1025B        |     2,426.5 ns |      6.23 ns |      5.53 ns |     2,425.1 ns |      96 B |
| **ComputeHash | SHA-1 | CryptoHives**                           | **1025B**        |     **2,473.4 ns** |      **8.24 ns** |      **7.71 ns** |     **2,472.4 ns** |      **96 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-1 | OS Native**                             | **8KB**          |     **8,078.9 ns** |     **20.28 ns** |     **18.97 ns** |     **8,082.4 ns** |      **96 B** |
| ComputeHash | SHA-1 | BouncyCastle                          | 8KB          |    18,117.5 ns |     65.69 ns |     58.23 ns |    18,127.0 ns |      96 B |
| **ComputeHash | SHA-1 | CryptoHives**                           | **8KB**          |    **18,352.0 ns** |     **71.82 ns** |     **67.18 ns** |    **18,347.8 ns** |      **96 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-1 | OS Native**                             | **128KB**        |   **126,893.8 ns** |    **366.78 ns** |    **343.09 ns** |   **126,824.0 ns** |      **96 B** |
| ComputeHash | SHA-1 | BouncyCastle                          | 128KB        |   286,189.9 ns |    488.90 ns |    408.25 ns |   286,280.2 ns |      96 B |
| **ComputeHash | SHA-1 | CryptoHives**                           | **128KB**        |   **290,190.9 ns** |    **774.79 ns** |    **686.83 ns** |   **290,185.3 ns** |      **96 B** |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHA-224 | CryptoHives                         | 128B         |       585.4 ns |      2.24 ns |      2.09 ns |       584.8 ns |     112 B |
| **ComputeHash | SHA-224 | BouncyCastle**                        | **128B**         |       **603.4 ns** |      **1.72 ns** |      **1.61 ns** |       **602.6 ns** |     **112 B** |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHA-224 | BouncyCastle                        | 137B         |       578.4 ns |      2.20 ns |      2.05 ns |       578.3 ns |     112 B |
| **ComputeHash | SHA-224 | CryptoHives**                         | **137B**         |       **604.8 ns** |      **2.65 ns** |      **2.48 ns** |       **604.5 ns** |     **112 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-224 | BouncyCastle**                        | **1KB**          |     **3,090.0 ns** |      **9.52 ns** |      **8.91 ns** |     **3,089.9 ns** |     **112 B** |
| **ComputeHash | SHA-224 | CryptoHives**                         | **1KB**          |     **3,171.0 ns** |      **9.46 ns** |      **8.39 ns** |     **3,170.1 ns** |     **112 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-224 | BouncyCastle**                        | **1025B**        |     **3,082.4 ns** |      **4.80 ns** |      **3.75 ns** |     **3,082.5 ns** |     **112 B** |
| **ComputeHash | SHA-224 | CryptoHives**                         | **1025B**        |     **3,175.2 ns** |     **12.26 ns** |     **11.47 ns** |     **3,172.1 ns** |     **112 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-224 | BouncyCastle**                        | **8KB**          |    **23,030.8 ns** |     **69.90 ns** |     **58.37 ns** |    **23,013.5 ns** |     **112 B** |
| **ComputeHash | SHA-224 | CryptoHives**                         | **8KB**          |    **23,666.8 ns** |     **80.67 ns** |     **75.45 ns** |    **23,706.1 ns** |     **112 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-224 | BouncyCastle**                        | **128KB**        |   **365,526.7 ns** |  **1,108.78 ns** |  **1,037.15 ns** |   **365,529.4 ns** |     **112 B** |
| **ComputeHash | SHA-224 | CryptoHives**                         | **128KB**        |   **374,055.3 ns** |    **623.63 ns** |    **552.83 ns** |   **374,149.5 ns** |     **112 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-256 | OS Native**                           | **128B**         |       **129.3 ns** |      **0.38 ns** |      **0.35 ns** |       **129.3 ns** |     **112 B** |
| ComputeHash | SHA-256 | BouncyCastle                        | 128B         |       567.7 ns |      1.42 ns |      1.18 ns |       567.9 ns |     112 B |
| **ComputeHash | SHA-256 | CryptoHives**                         | **128B**         |       **604.9 ns** |      **1.54 ns** |      **1.36 ns** |       **605.1 ns** |     **112 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-256 | OS Native**                           | **137B**         |       **130.1 ns** |      **0.29 ns** |      **0.24 ns** |       **130.1 ns** |     **112 B** |
| ComputeHash | SHA-256 | BouncyCastle                        | 137B         |       568.6 ns |      1.83 ns |      1.53 ns |       568.8 ns |     112 B |
| **ComputeHash | SHA-256 | CryptoHives**                         | **137B**         |       **602.5 ns** |      **1.71 ns** |      **1.52 ns** |       **602.4 ns** |     **112 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-256 | OS Native**                           | **1KB**          |       **485.9 ns** |      **0.90 ns** |      **0.80 ns** |       **485.9 ns** |     **112 B** |
| ComputeHash | SHA-256 | BouncyCastle                        | 1KB          |     3,038.8 ns |      7.93 ns |      7.41 ns |     3,037.6 ns |     112 B |
| **ComputeHash | SHA-256 | CryptoHives**                         | **1KB**          |     **3,154.6 ns** |     **10.07 ns** |      **9.42 ns** |     **3,151.2 ns** |     **112 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-256 | OS Native**                           | **1025B**        |       **484.6 ns** |      **0.94 ns** |      **0.84 ns** |       **484.7 ns** |     **112 B** |
| ComputeHash | SHA-256 | BouncyCastle                        | 1025B        |     3,043.0 ns |     10.10 ns |      9.45 ns |     3,044.9 ns |     112 B |
| **ComputeHash | SHA-256 | CryptoHives**                         | **1025B**        |     **3,159.9 ns** |      **8.75 ns** |      **8.19 ns** |     **3,158.9 ns** |     **112 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-256 | OS Native**                           | **8KB**          |     **3,279.5 ns** |      **4.79 ns** |      **4.25 ns** |     **3,278.2 ns** |     **112 B** |
| ComputeHash | SHA-256 | BouncyCastle                        | 8KB          |    22,711.3 ns |     39.99 ns |     33.39 ns |    22,708.0 ns |     112 B |
| **ComputeHash | SHA-256 | CryptoHives**                         | **8KB**          |    **23,549.1 ns** |     **94.25 ns** |     **83.55 ns** |    **23,525.0 ns** |     **112 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-256 | OS Native**                           | **128KB**        |    **51,183.8 ns** |    **116.53 ns** |    **103.30 ns** |    **51,170.0 ns** |     **112 B** |
| ComputeHash | SHA-256 | BouncyCastle                        | 128KB        |   360,983.6 ns |    625.54 ns |    522.35 ns |   360,941.5 ns |     112 B |
| **ComputeHash | SHA-256 | CryptoHives**                         | **128KB**        |   **372,514.5 ns** |  **1,252.40 ns** |  **1,171.49 ns** |   **372,148.5 ns** |     **112 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-384 | OS Native**                           | **128B**         |       **370.9 ns** |      **1.02 ns** |      **0.95 ns** |       **370.7 ns** |     **144 B** |
| ComputeHash | SHA-384 | BouncyCastle                        | 128B         |       504.1 ns |      2.62 ns |      2.33 ns |       504.1 ns |     144 B |
| **ComputeHash | SHA-384 | CryptoHives**                         | **128B**         |       **535.8 ns** |      **1.52 ns** |      **1.35 ns** |       **535.7 ns** |     **144 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-384 | OS Native**                           | **137B**         |       **371.4 ns** |      **1.32 ns** |      **1.23 ns** |       **370.8 ns** |     **144 B** |
| ComputeHash | SHA-384 | BouncyCastle                        | 137B         |       503.2 ns |      1.87 ns |      1.66 ns |       503.4 ns |     144 B |
| **ComputeHash | SHA-384 | CryptoHives**                         | **137B**         |       **534.7 ns** |      **2.72 ns** |      **2.41 ns** |       **534.3 ns** |     **144 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-384 | OS Native**                           | **1KB**          |     **1,410.8 ns** |      **4.24 ns** |      **3.97 ns** |     **1,410.1 ns** |     **144 B** |
| ComputeHash | SHA-384 | BouncyCastle                        | 1KB          |     2,096.0 ns |      6.68 ns |      6.25 ns |     2,096.1 ns |     144 B |
| **ComputeHash | SHA-384 | CryptoHives**                         | **1KB**          |     **2,121.6 ns** |      **7.21 ns** |      **6.74 ns** |     **2,122.2 ns** |     **144 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-384 | OS Native**                           | **1025B**        |     **1,409.6 ns** |      **5.39 ns** |      **5.04 ns** |     **1,410.2 ns** |     **144 B** |
| ComputeHash | SHA-384 | BouncyCastle                        | 1025B        |     2,102.4 ns |      6.93 ns |      6.48 ns |     2,102.5 ns |     144 B |
| **ComputeHash | SHA-384 | CryptoHives**                         | **1025B**        |     **2,123.4 ns** |      **5.59 ns** |      **5.23 ns** |     **2,123.5 ns** |     **144 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-384 | OS Native**                           | **8KB**          |     **9,691.6 ns** |     **38.15 ns** |     **35.69 ns** |     **9,696.3 ns** |     **144 B** |
| **ComputeHash | SHA-384 | CryptoHives**                         | **8KB**          |    **14,728.8 ns** |     **29.98 ns** |     **28.05 ns** |    **14,718.3 ns** |     **144 B** |
| **ComputeHash | SHA-384 | BouncyCastle**                        | **8KB**          |    **14,839.9 ns** |     **51.51 ns** |     **48.19 ns** |    **14,847.0 ns** |     **144 B** |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHA-384 | OS Native                           | 128KB        |   151,732.7 ns |    635.73 ns |    563.56 ns |   151,682.8 ns |     144 B |
| **ComputeHash | SHA-384 | CryptoHives**                         | **128KB**        |   **231,003.7 ns** |    **372.74 ns** |    **311.25 ns** |   **230,998.2 ns** |     **144 B** |
| **ComputeHash | SHA-384 | BouncyCastle**                        | **128KB**        |   **232,714.9 ns** |    **515.06 ns** |    **430.10 ns** |   **232,553.4 ns** |     **144 B** |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHA-512 | OS Native                           | 128B         |       368.0 ns |      0.56 ns |      0.43 ns |       368.1 ns |     176 B |
| ComputeHash | SHA-512 | BouncyCastle                        | 128B         |       504.3 ns |      1.24 ns |      1.16 ns |       503.8 ns |     176 B |
| **ComputeHash | SHA-512 | CryptoHives**                         | **128B**         |       **559.3 ns** |      **2.14 ns** |      **1.78 ns** |       **558.9 ns** |     **176 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-512 | OS Native**                           | **137B**         |       **368.1 ns** |      **1.47 ns** |      **1.38 ns** |       **368.1 ns** |     **176 B** |
| ComputeHash | SHA-512 | BouncyCastle                        | 137B         |       505.8 ns |      1.72 ns |      1.60 ns |       505.6 ns |     176 B |
| **ComputeHash | SHA-512 | CryptoHives**                         | **137B**         |       **556.9 ns** |      **1.70 ns** |      **1.59 ns** |       **556.5 ns** |     **176 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-512 | OS Native**                           | **1KB**          |     **1,419.4 ns** |      **4.90 ns** |      **4.58 ns** |     **1,419.2 ns** |     **176 B** |
| ComputeHash | SHA-512 | BouncyCastle                        | 1KB          |     2,099.3 ns |      6.71 ns |      6.28 ns |     2,100.8 ns |     176 B |
| **ComputeHash | SHA-512 | CryptoHives**                         | **1KB**          |     **2,223.7 ns** |      **8.97 ns** |      **7.95 ns** |     **2,227.0 ns** |     **176 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-512 | OS Native**                           | **1025B**        |     **1,407.5 ns** |      **3.81 ns** |      **3.38 ns** |     **1,406.6 ns** |     **176 B** |
| ComputeHash | SHA-512 | BouncyCastle                        | 1025B        |     2,106.9 ns |      5.05 ns |      4.73 ns |     2,105.6 ns |     176 B |
| **ComputeHash | SHA-512 | CryptoHives**                         | **1025B**        |     **2,227.7 ns** |      **9.26 ns** |      **8.66 ns** |     **2,224.7 ns** |     **176 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-512 | OS Native**                           | **8KB**          |     **9,691.5 ns** |     **23.73 ns** |     **21.04 ns** |     **9,693.9 ns** |     **176 B** |
| ComputeHash | SHA-512 | BouncyCastle                        | 8KB          |    14,832.1 ns |     41.97 ns |     39.26 ns |    14,829.5 ns |     176 B |
| **ComputeHash | SHA-512 | CryptoHives**                         | **8KB**          |    **15,479.6 ns** |     **59.58 ns** |     **55.73 ns** |    **15,478.1 ns** |     **176 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-512 | OS Native**                           | **128KB**        |   **151,449.8 ns** |    **522.94 ns** |    **463.57 ns** |   **151,444.8 ns** |     **176 B** |
| ComputeHash | SHA-512 | BouncyCastle                        | 128KB        |   233,395.2 ns |    275.78 ns |    215.31 ns |   233,355.3 ns |     176 B |
| **ComputeHash | SHA-512 | CryptoHives**                         | **128KB**        |   **242,699.7 ns** |    **507.86 ns** |    **450.21 ns** |   **242,784.0 ns** |     **176 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-512/224 | BouncyCastle**                    | **128B**         |       **517.0 ns** |      **1.63 ns** |      **1.52 ns** |       **516.6 ns** |     **112 B** |
| **ComputeHash | SHA-512/224 | CryptoHives**                     | **128B**         |       **532.9 ns** |      **1.33 ns** |      **1.11 ns** |       **533.2 ns** |     **112 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-512/224 | BouncyCastle**                    | **137B**         |       **518.8 ns** |      **1.03 ns** |      **0.91 ns** |       **518.6 ns** |     **112 B** |
| **ComputeHash | SHA-512/224 | CryptoHives**                     | **137B**         |       **531.5 ns** |      **1.95 ns** |      **1.83 ns** |       **532.1 ns** |     **112 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-512/224 | BouncyCastle**                    | **1KB**          |     **2,111.8 ns** |      **8.38 ns** |      **7.43 ns** |     **2,111.5 ns** |     **112 B** |
| **ComputeHash | SHA-512/224 | CryptoHives**                     | **1KB**          |     **2,127.5 ns** |      **7.28 ns** |      **6.81 ns** |     **2,127.8 ns** |     **112 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-512/224 | BouncyCastle**                    | **1025B**        |     **2,119.7 ns** |      **5.21 ns** |      **4.87 ns** |     **2,118.6 ns** |     **112 B** |
| **ComputeHash | SHA-512/224 | CryptoHives**                     | **1025B**        |     **2,120.4 ns** |      **9.39 ns** |      **8.78 ns** |     **2,119.5 ns** |     **112 B** |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHA-512/224 | CryptoHives                     | 8KB          |    14,737.0 ns |     39.80 ns |     37.23 ns |    14,738.5 ns |     112 B |
| **ComputeHash | SHA-512/224 | BouncyCastle**                    | **8KB**          |    **14,835.8 ns** |     **39.67 ns** |     **37.10 ns** |    **14,821.5 ns** |     **112 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-512/224 | CryptoHives**                     | **128KB**        |   **231,176.7 ns** |    **595.31 ns** |    **556.85 ns** |   **230,970.9 ns** |     **112 B** |
| **ComputeHash | SHA-512/224 | BouncyCastle**                    | **128KB**        |   **232,783.1 ns** |    **313.05 ns** |    **277.51 ns** |   **232,643.6 ns** |     **112 B** |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHA-512/256 | BouncyCastle                    | 128B         |       514.0 ns |      1.51 ns |      1.41 ns |       514.0 ns |     112 B |
| **ComputeHash | SHA-512/256 | CryptoHives**                     | **128B**         |       **532.8 ns** |      **2.04 ns** |      **1.81 ns** |       **532.8 ns** |     **112 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-512/256 | BouncyCastle**                    | **137B**         |       **521.9 ns** |      **1.94 ns** |      **1.81 ns** |       **522.2 ns** |     **112 B** |
| **ComputeHash | SHA-512/256 | CryptoHives**                     | **137B**         |       **531.5 ns** |      **1.78 ns** |      **1.58 ns** |       **531.1 ns** |     **112 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-512/256 | BouncyCastle**                    | **1KB**          |     **2,114.3 ns** |     **10.90 ns** |     **10.20 ns** |     **2,113.3 ns** |     **112 B** |
| **ComputeHash | SHA-512/256 | CryptoHives**                     | **1KB**          |     **2,119.1 ns** |     **10.37 ns** |      **9.70 ns** |     **2,118.7 ns** |     **112 B** |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHA-512/256 | CryptoHives                     | 1025B        |     2,117.8 ns |      8.35 ns |      7.81 ns |     2,117.2 ns |     112 B |
| **ComputeHash | SHA-512/256 | BouncyCastle**                    | **1025B**        |     **2,121.6 ns** |      **6.51 ns** |      **5.44 ns** |     **2,120.5 ns** |     **112 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-512/256 | CryptoHives**                     | **8KB**          |    **14,730.4 ns** |     **23.17 ns** |     **20.54 ns** |    **14,729.0 ns** |     **112 B** |
| **ComputeHash | SHA-512/256 | BouncyCastle**                    | **8KB**          |    **14,836.0 ns** |     **32.33 ns** |     **30.24 ns** |    **14,833.9 ns** |     **112 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SHA-512/256 | CryptoHives**                     | **128KB**        |   **231,989.1 ns** |    **703.52 ns** |    **658.07 ns** |   **231,735.3 ns** |     **112 B** |
| **ComputeHash | SHA-512/256 | BouncyCastle**                    | **128KB**        |   **233,139.8 ns** |    **548.98 ns** |    **513.51 ns** |   **233,050.8 ns** |     **112 B** |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Scalar            | 128B         |       239.2 ns |      1.07 ns |      1.00 ns |       238.9 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx512F           | 128B         |       318.4 ns |      0.90 ns |      0.70 ns |       318.6 ns |     112 B |
| ComputeHash | SHA3-224 | BouncyCastle                       | 128B         |       357.7 ns |      1.16 ns |      1.03 ns |       357.6 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Scalar            | 137B         |       235.3 ns |      0.35 ns |      0.33 ns |       235.3 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx512F           | 137B         |       313.9 ns |      0.80 ns |      0.74 ns |       313.7 ns |     112 B |
| ComputeHash | SHA3-224 | BouncyCastle                       | 137B         |       358.3 ns |      1.26 ns |      1.18 ns |       357.9 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Scalar            | 1KB          |     1,673.3 ns |      2.87 ns |      2.69 ns |     1,672.7 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx512F           | 1KB          |     2,314.6 ns |      5.82 ns |      5.44 ns |     2,313.8 ns |     112 B |
| ComputeHash | SHA3-224 | BouncyCastle                       | 1KB          |     2,470.6 ns |      6.00 ns |      5.32 ns |     2,469.5 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Scalar            | 1025B        |     1,672.7 ns |      5.79 ns |      5.41 ns |     1,671.1 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx512F           | 1025B        |     2,306.2 ns |      5.59 ns |      5.23 ns |     2,308.0 ns |     112 B |
| ComputeHash | SHA3-224 | BouncyCastle                       | 1025B        |     2,472.9 ns |     13.23 ns |     12.38 ns |     2,465.7 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Scalar            | 8KB          |    11,401.4 ns |     48.74 ns |     45.59 ns |    11,390.5 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx512F           | 8KB          |    15,932.5 ns |     27.40 ns |     24.29 ns |    15,932.3 ns |     112 B |
| ComputeHash | SHA3-224 | BouncyCastle                       | 8KB          |    17,305.2 ns |     63.53 ns |     59.43 ns |    17,305.6 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Scalar            | 128KB        |   181,497.3 ns |    793.46 ns |    703.38 ns |   181,112.2 ns |     112 B |
| ComputeHash | SHA3-224 | SHA3_224_Managed_Avx512F           | 128KB        |   253,997.3 ns |    545.35 ns |    455.39 ns |   254,058.7 ns |     112 B |
| ComputeHash | SHA3-224 | BouncyCastle                       | 128KB        |   275,448.5 ns |  1,132.09 ns |  1,003.56 ns |   275,337.8 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar            | 128B         |       234.5 ns |      0.77 ns |      0.72 ns |       234.5 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native                          | 128B         |       295.9 ns |      1.18 ns |      1.10 ns |       295.6 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx512F           | 128B         |       314.4 ns |      0.92 ns |      0.81 ns |       314.4 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle                       | 128B         |       361.8 ns |      1.35 ns |      1.26 ns |       361.4 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar            | 137B         |       479.7 ns |      1.72 ns |      1.61 ns |       479.2 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native                          | 137B         |       526.7 ns |      1.52 ns |      1.27 ns |       526.9 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx512F           | 137B         |       636.9 ns |      1.07 ns |      0.95 ns |       637.0 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle                       | 137B         |       646.5 ns |      1.67 ns |      1.56 ns |       646.9 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar            | 1KB          |     1,647.8 ns |      3.91 ns |      3.46 ns |     1,647.8 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native                          | 1KB          |     1,934.3 ns |      7.86 ns |      6.97 ns |     1,934.8 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx512F           | 1KB          |     2,272.2 ns |      5.86 ns |      5.49 ns |     2,272.2 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle                       | 1KB          |     2,464.1 ns |      8.04 ns |      7.12 ns |     2,462.2 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar            | 1025B        |     1,644.2 ns |      2.02 ns |      1.58 ns |     1,644.1 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native                          | 1025B        |     1,931.2 ns |      4.75 ns |      4.21 ns |     1,931.3 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx512F           | 1025B        |     2,275.7 ns |      5.82 ns |      5.44 ns |     2,277.0 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle                       | 1025B        |     2,469.8 ns |      9.16 ns |      8.57 ns |     2,470.3 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar            | 8KB          |    12,178.0 ns |     45.77 ns |     42.81 ns |    12,158.9 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native                          | 8KB          |    14,278.0 ns |     47.88 ns |     42.45 ns |    14,284.9 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx512F           | 8KB          |    16,983.8 ns |     86.29 ns |     72.06 ns |    16,967.8 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle                       | 8KB          |    18,490.4 ns |     63.58 ns |     59.47 ns |    18,479.9 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Scalar            | 128KB        |   190,931.5 ns |    600.31 ns |    561.54 ns |   190,796.8 ns |     112 B |
| ComputeHash | SHA3-256 | OS Native                          | 128KB        |   225,276.0 ns |    807.73 ns |    755.55 ns |   225,422.4 ns |     112 B |
| ComputeHash | SHA3-256 | SHA3_256_Managed_Avx512F           | 128KB        |   266,709.4 ns |    719.87 ns |    638.15 ns |   266,693.1 ns |     112 B |
| ComputeHash | SHA3-256 | BouncyCastle                       | 128KB        |   291,289.9 ns |    831.91 ns |    778.17 ns |   291,275.0 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Scalar            | 128B         |       455.7 ns |      1.45 ns |      1.35 ns |       455.8 ns |     144 B |
| ComputeHash | SHA3-384 | OS Native                          | 128B         |       524.8 ns |      0.99 ns |      0.83 ns |       525.0 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx512F           | 128B         |       615.7 ns |      2.36 ns |      1.97 ns |       615.3 ns |     144 B |
| ComputeHash | SHA3-384 | BouncyCastle                       | 128B         |       644.9 ns |      1.61 ns |      1.51 ns |       644.8 ns |     144 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Scalar            | 137B         |       453.4 ns |      1.09 ns |      1.02 ns |       453.6 ns |     144 B |
| ComputeHash | SHA3-384 | OS Native                          | 137B         |       527.8 ns |      3.34 ns |      3.12 ns |       526.0 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx512F           | 137B         |       611.9 ns |      1.58 ns |      1.32 ns |       612.1 ns |     144 B |
| ComputeHash | SHA3-384 | BouncyCastle                       | 137B         |       646.9 ns |      2.43 ns |      2.27 ns |       647.1 ns |     144 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Scalar            | 1KB          |     2,002.7 ns |      6.20 ns |      5.50 ns |     2,004.4 ns |     144 B |
| ComputeHash | SHA3-384 | OS Native                          | 1KB          |     2,386.8 ns |      7.28 ns |      6.81 ns |     2,385.5 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx512F           | 1KB          |     2,786.3 ns |      5.16 ns |      4.03 ns |     2,786.2 ns |     144 B |
| ComputeHash | SHA3-384 | BouncyCastle                       | 1KB          |     3,048.1 ns |      7.15 ns |      6.69 ns |     3,047.1 ns |     144 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Scalar            | 1025B        |     2,011.9 ns |      9.44 ns |      8.83 ns |     2,010.8 ns |     144 B |
| ComputeHash | SHA3-384 | OS Native                          | 1025B        |     2,385.5 ns |      5.32 ns |      4.44 ns |     2,386.6 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx512F           | 1025B        |     2,802.5 ns |     23.89 ns |     19.95 ns |     2,796.8 ns |     144 B |
| ComputeHash | SHA3-384 | BouncyCastle                       | 1025B        |     3,063.0 ns |     11.88 ns |     11.11 ns |     3,064.9 ns |     144 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Scalar            | 8KB          |    15,565.8 ns |     51.61 ns |     48.28 ns |    15,546.3 ns |     144 B |
| ComputeHash | SHA3-384 | OS Native                          | 8KB          |    18,351.2 ns |     75.18 ns |     70.32 ns |    18,339.0 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx512F           | 8KB          |    21,759.6 ns |     43.67 ns |     40.85 ns |    21,754.8 ns |     144 B |
| ComputeHash | SHA3-384 | BouncyCastle                       | 8KB          |    23,780.4 ns |     83.50 ns |     78.11 ns |    23,798.3 ns |     144 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Scalar            | 128KB        |   247,184.7 ns |  1,118.31 ns |    933.84 ns |   247,055.8 ns |     144 B |
| ComputeHash | SHA3-384 | OS Native                          | 128KB        |   291,795.1 ns |  1,240.60 ns |  1,160.45 ns |   291,942.7 ns |     144 B |
| ComputeHash | SHA3-384 | SHA3_384_Managed_Avx512F           | 128KB        |   345,676.0 ns |    713.24 ns |    595.59 ns |   345,531.2 ns |     144 B |
| ComputeHash | SHA3-384 | BouncyCastle                       | 128KB        |   377,145.4 ns |  1,215.19 ns |  1,077.23 ns |   377,037.6 ns |     144 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Scalar            | 128B         |       431.4 ns |      1.52 ns |      1.35 ns |       431.1 ns |     176 B |
| ComputeHash | SHA3-512 | OS Native                          | 128B         |       545.6 ns |      2.16 ns |      2.02 ns |       545.8 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx512F           | 128B         |       591.0 ns |      1.64 ns |      1.53 ns |       591.0 ns |     176 B |
| ComputeHash | SHA3-512 | BouncyCastle                       | 128B         |       646.4 ns |      2.77 ns |      2.46 ns |       645.7 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Scalar            | 137B         |       427.5 ns |      1.46 ns |      1.36 ns |       427.5 ns |     176 B |
| ComputeHash | SHA3-512 | OS Native                          | 137B         |       526.8 ns |      2.07 ns |      1.94 ns |       526.1 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx512F           | 137B         |       583.6 ns |      1.45 ns |      1.28 ns |       583.8 ns |     176 B |
| ComputeHash | SHA3-512 | BouncyCastle                       | 137B         |       645.9 ns |      2.73 ns |      2.56 ns |       644.9 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Scalar            | 1KB          |     2,969.3 ns |     11.65 ns |     10.90 ns |     2,969.1 ns |     176 B |
| ComputeHash | SHA3-512 | OS Native                          | 1KB          |     3,515.1 ns |      9.73 ns |      8.63 ns |     3,515.7 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx512F           | 1KB          |     4,169.6 ns |     10.26 ns |      9.10 ns |     4,172.4 ns |     176 B |
| ComputeHash | SHA3-512 | BouncyCastle                       | 1KB          |     4,507.5 ns |     10.93 ns |      9.69 ns |     4,508.4 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Scalar            | 1025B        |     2,976.3 ns |     13.96 ns |     13.06 ns |     2,977.1 ns |     176 B |
| ComputeHash | SHA3-512 | OS Native                          | 1025B        |     3,530.3 ns |      4.81 ns |      4.50 ns |     3,530.0 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx512F           | 1025B        |     4,163.2 ns |      9.26 ns |      8.66 ns |     4,161.4 ns |     176 B |
| ComputeHash | SHA3-512 | BouncyCastle                       | 1025B        |     4,524.2 ns |     11.71 ns |     10.96 ns |     4,525.0 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Scalar            | 8KB          |    22,187.6 ns |     72.23 ns |     67.56 ns |    22,205.7 ns |     176 B |
| ComputeHash | SHA3-512 | OS Native                          | 8KB          |    26,398.1 ns |    123.51 ns |    115.53 ns |    26,358.1 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx512F           | 8KB          |    31,292.1 ns |    123.35 ns |     96.30 ns |    31,320.8 ns |     176 B |
| ComputeHash | SHA3-512 | BouncyCastle                       | 8KB          |    34,219.3 ns |     73.16 ns |     64.86 ns |    34,235.1 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Scalar            | 128KB        |   354,355.2 ns |  1,350.85 ns |  1,263.58 ns |   354,480.0 ns |     176 B |
| ComputeHash | SHA3-512 | OS Native                          | 128KB        |   418,104.0 ns |    789.32 ns |    738.33 ns |   418,011.4 ns |     176 B |
| ComputeHash | SHA3-512 | SHA3_512_Managed_Avx512F           | 128KB        |   498,865.1 ns |  1,260.71 ns |  1,117.58 ns |   498,874.0 ns |     176 B |
| ComputeHash | SHA3-512 | BouncyCastle                       | 128KB        |   548,229.3 ns |  1,173.63 ns |  1,040.39 ns |   547,977.9 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHAKE128 | Shake128_Managed_Scalar            | 128B         |       269.6 ns |      0.89 ns |      0.83 ns |       269.8 ns |     112 B |
| ComputeHash | SHAKE128 | Shake128_Managed_Avx512F           | 128B         |       344.6 ns |      0.72 ns |      0.67 ns |       344.5 ns |     112 B |
| ComputeHash | SHAKE128 | BouncyCastle                       | 128B         |       356.1 ns |      0.65 ns |      0.58 ns |       355.9 ns |     112 B |
| ComputeHash | SHAKE128 | OS Native                          | 128B         |       375.0 ns |      1.18 ns |      1.11 ns |       374.8 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHAKE128 | Shake128_Managed_Scalar            | 137B         |       272.4 ns |      0.89 ns |      0.79 ns |       272.1 ns |     112 B |
| ComputeHash | SHAKE128 | BouncyCastle                       | 137B         |       359.1 ns |      1.21 ns |      1.07 ns |       359.3 ns |     112 B |
| ComputeHash | SHAKE128 | Shake128_Managed_Avx512F           | 137B         |       360.8 ns |      0.86 ns |      0.80 ns |       360.7 ns |     112 B |
| ComputeHash | SHAKE128 | OS Native                          | 137B         |       375.6 ns |      1.61 ns |      1.50 ns |       375.2 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHAKE128 | Shake128_Managed_Scalar            | 1KB          |     1,506.0 ns |      6.64 ns |      6.21 ns |     1,504.2 ns |     112 B |
| ComputeHash | SHAKE128 | OS Native                          | 1KB          |     1,796.0 ns |      3.66 ns |      3.25 ns |     1,795.0 ns |     112 B |
| ComputeHash | SHAKE128 | Shake128_Managed_Avx512F           | 1KB          |     2,058.3 ns |      4.94 ns |      4.38 ns |     2,057.9 ns |     112 B |
| ComputeHash | SHAKE128 | BouncyCastle                       | 1KB          |     2,180.1 ns |      6.78 ns |      6.35 ns |     2,180.5 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHAKE128 | Shake128_Managed_Scalar            | 1025B        |     1,519.0 ns |      4.25 ns |      3.76 ns |     1,518.8 ns |     112 B |
| ComputeHash | SHAKE128 | OS Native                          | 1025B        |     1,805.8 ns |     12.45 ns |     11.65 ns |     1,802.8 ns |     112 B |
| ComputeHash | SHAKE128 | Shake128_Managed_Avx512F           | 1025B        |     2,055.1 ns |      4.41 ns |      4.13 ns |     2,055.4 ns |     112 B |
| ComputeHash | SHAKE128 | BouncyCastle                       | 1025B        |     2,173.1 ns |      7.14 ns |      6.68 ns |     2,174.4 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHAKE128 | Shake128_Managed_Scalar            | 8KB          |     9,857.6 ns |     26.02 ns |     24.34 ns |     9,852.2 ns |     112 B |
| ComputeHash | SHAKE128 | OS Native                          | 8KB          |    11,672.2 ns |     54.03 ns |     47.89 ns |    11,652.2 ns |     112 B |
| ComputeHash | SHAKE128 | Shake128_Managed_Avx512F           | 8KB          |    13,711.5 ns |     19.36 ns |     16.16 ns |    13,702.8 ns |     112 B |
| ComputeHash | SHAKE128 | BouncyCastle                       | 8KB          |    14,960.2 ns |     35.97 ns |     33.64 ns |    14,963.3 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHAKE128 | Shake128_Managed_Scalar            | 128KB        |   155,548.7 ns |    577.93 ns |    540.60 ns |   155,430.3 ns |     112 B |
| ComputeHash | SHAKE128 | OS Native                          | 128KB        |   183,607.0 ns |    578.73 ns |    513.03 ns |   183,655.4 ns |     112 B |
| ComputeHash | SHAKE128 | Shake128_Managed_Avx512F           | 128KB        |   218,487.7 ns |  3,310.49 ns |  2,764.41 ns |   217,412.9 ns |     112 B |
| ComputeHash | SHAKE128 | BouncyCastle                       | 128KB        |   244,060.0 ns |    884.13 ns |    827.02 ns |   244,180.6 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHAKE256 | Shake256_Managed_Scalar            | 128B         |       278.3 ns |      1.13 ns |      1.06 ns |       278.2 ns |     176 B |
| ComputeHash | SHAKE256 | Shake256_Managed_Avx512F           | 128B         |       351.8 ns |      0.55 ns |      0.51 ns |       351.7 ns |     176 B |
| ComputeHash | SHAKE256 | BouncyCastle                       | 128B         |       357.5 ns |      1.42 ns |      1.33 ns |       357.3 ns |     176 B |
| ComputeHash | SHAKE256 | OS Native                          | 128B         |       377.3 ns |      1.70 ns |      1.59 ns |       377.4 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHAKE256 | Shake256_Managed_Scalar            | 137B         |       521.7 ns |      0.99 ns |      0.93 ns |       522.0 ns |     176 B |
| ComputeHash | SHAKE256 | OS Native                          | 137B         |       612.6 ns |      1.67 ns |      1.48 ns |       612.9 ns |     176 B |
| ComputeHash | SHAKE256 | BouncyCastle                       | 137B         |       663.5 ns |      1.65 ns |      1.46 ns |       663.7 ns |     176 B |
| ComputeHash | SHAKE256 | Shake256_Managed_Avx512F           | 137B         |       677.9 ns |      1.31 ns |      1.16 ns |       677.9 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHAKE256 | Shake256_Managed_Scalar            | 1KB          |     1,686.6 ns |      5.80 ns |      5.14 ns |     1,686.1 ns |     176 B |
| ComputeHash | SHAKE256 | OS Native                          | 1KB          |     2,021.4 ns |      6.20 ns |      5.80 ns |     2,021.4 ns |     176 B |
| ComputeHash | SHAKE256 | Shake256_Managed_Avx512F           | 1KB          |     2,311.4 ns |      9.35 ns |      8.29 ns |     2,310.9 ns |     176 B |
| ComputeHash | SHAKE256 | BouncyCastle                       | 1KB          |     2,468.2 ns |     13.29 ns |     12.44 ns |     2,460.8 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHAKE256 | Shake256_Managed_Scalar            | 1025B        |     1,689.5 ns |      5.68 ns |      5.03 ns |     1,689.8 ns |     176 B |
| ComputeHash | SHAKE256 | OS Native                          | 1025B        |     2,020.7 ns |     10.08 ns |      9.43 ns |     2,016.2 ns |     176 B |
| ComputeHash | SHAKE256 | Shake256_Managed_Avx512F           | 1025B        |     2,308.3 ns |      4.22 ns |      3.74 ns |     2,308.3 ns |     176 B |
| ComputeHash | SHAKE256 | BouncyCastle                       | 1025B        |     2,476.1 ns |      5.23 ns |      4.89 ns |     2,475.0 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHAKE256 | Shake256_Managed_Scalar            | 8KB          |    12,213.1 ns |     27.82 ns |     26.02 ns |    12,219.5 ns |     176 B |
| ComputeHash | SHAKE256 | OS Native                          | 8KB          |    14,369.9 ns |     30.86 ns |     28.87 ns |    14,368.8 ns |     176 B |
| ComputeHash | SHAKE256 | Shake256_Managed_Avx512F           | 8KB          |    16,987.1 ns |     44.29 ns |     39.26 ns |    16,992.1 ns |     176 B |
| ComputeHash | SHAKE256 | BouncyCastle                       | 8KB          |    18,446.5 ns |     65.14 ns |     57.75 ns |    18,448.1 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SHAKE256 | Shake256_Managed_Scalar            | 128KB        |   191,436.8 ns |    842.26 ns |    787.85 ns |   191,710.2 ns |     176 B |
| ComputeHash | SHAKE256 | OS Native                          | 128KB        |   225,282.6 ns |    625.69 ns |    554.66 ns |   225,387.6 ns |     176 B |
| ComputeHash | SHAKE256 | Shake256_Managed_Avx512F           | 128KB        |   266,712.9 ns |    366.74 ns |    325.11 ns |   266,739.8 ns |     176 B |
| ComputeHash | SHAKE256 | BouncyCastle                       | 128KB        |   291,254.2 ns |    554.16 ns |    518.36 ns |   291,215.2 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | SM3 | BouncyCastle                            | 128B         |       812.6 ns |      2.04 ns |      1.80 ns |       812.7 ns |     112 B |
| **ComputeHash | SM3 | CryptoHives**                             | **128B**         |       **949.5 ns** |      **2.48 ns** |      **2.20 ns** |       **949.5 ns** |     **112 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SM3 | BouncyCastle**                            | **137B**         |       **820.8 ns** |      **1.50 ns** |      **1.33 ns** |       **821.0 ns** |     **112 B** |
| **ComputeHash | SM3 | CryptoHives**                             | **137B**         |       **944.1 ns** |      **1.24 ns** |      **1.16 ns** |       **943.6 ns** |     **112 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SM3 | BouncyCastle**                            | **1KB**          |     **4,367.2 ns** |     **13.02 ns** |     **12.18 ns** |     **4,362.4 ns** |     **112 B** |
| **ComputeHash | SM3 | CryptoHives**                             | **1KB**          |     **5,175.4 ns** |     **10.03 ns** |      **8.38 ns** |     **5,173.4 ns** |     **112 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SM3 | BouncyCastle**                            | **1025B**        |     **4,374.2 ns** |     **12.97 ns** |     **12.13 ns** |     **4,374.4 ns** |     **112 B** |
| **ComputeHash | SM3 | CryptoHives**                             | **1025B**        |     **5,163.5 ns** |      **5.69 ns** |      **5.04 ns** |     **5,161.9 ns** |     **112 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SM3 | BouncyCastle**                            | **8KB**          |    **33,256.4 ns** |    **102.31 ns** |     **95.70 ns** |    **33,238.1 ns** |     **112 B** |
| **ComputeHash | SM3 | CryptoHives**                             | **8KB**          |    **38,837.2 ns** |     **61.58 ns** |     **57.61 ns** |    **38,829.4 ns** |     **112 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | SM3 | BouncyCastle**                            | **128KB**        |   **525,447.2 ns** |    **978.03 ns** |    **914.85 ns** |   **525,592.4 ns** |     **112 B** |
| **ComputeHash | SM3 | CryptoHives**                             | **128KB**        |   **616,123.2 ns** |  **1,040.97 ns** |    **973.73 ns** |   **616,042.6 ns** |     **112 B** |
|                                                             |              |                |              |              |                |           |
| ComputeHash | Streebog-256 | CryptoHives                    | 128B         |     2,416.8 ns |      3.44 ns |      3.22 ns |     2,417.3 ns |     112 B |
| **ComputeHash | Streebog-256 | OpenGost**                       | **128B**         |     **3,412.5 ns** |      **8.26 ns** |      **7.32 ns** |     **3,413.4 ns** |     **464 B** |
| ComputeHash | Streebog-256 | BouncyCastle                   | 128B         |     4,259.5 ns |     18.26 ns |     16.18 ns |     4,256.2 ns |     200 B |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | Streebog-256 | CryptoHives**                    | **137B**         |     **2,429.4 ns** |      **1.89 ns** |      **1.77 ns** |     **2,430.0 ns** |     **112 B** |
| **ComputeHash | Streebog-256 | OpenGost**                       | **137B**         |     **3,412.0 ns** |      **9.14 ns** |      **8.55 ns** |     **3,412.0 ns** |     **464 B** |
| ComputeHash | Streebog-256 | BouncyCastle                   | 137B         |     4,289.8 ns |     19.28 ns |     17.09 ns |     4,291.3 ns |     200 B |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | Streebog-256 | CryptoHives**                    | **1KB**          |     **9,252.0 ns** |     **18.77 ns** |     **16.64 ns** |     **9,249.9 ns** |     **112 B** |
| **ComputeHash | Streebog-256 | OpenGost**                       | **1KB**          |    **12,618.6 ns** |     **27.02 ns** |     **23.95 ns** |    **12,617.0 ns** |     **464 B** |
| ComputeHash | Streebog-256 | BouncyCastle                   | 1KB          |    16,097.2 ns |     51.32 ns |     45.50 ns |    16,105.9 ns |     200 B |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | Streebog-256 | CryptoHives**                    | **1025B**        |     **8,996.9 ns** |     **14.49 ns** |     **13.55 ns** |     **8,996.1 ns** |     **112 B** |
| **ComputeHash | Streebog-256 | OpenGost**                       | **1025B**        |    **12,607.7 ns** |     **26.58 ns** |     **23.56 ns** |    **12,606.8 ns** |     **464 B** |
| ComputeHash | Streebog-256 | BouncyCastle                   | 1025B        |    16,187.2 ns |     74.97 ns |     70.13 ns |    16,202.9 ns |     200 B |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | Streebog-256 | CryptoHives**                    | **8KB**          |    **62,117.9 ns** |    **125.04 ns** |    **116.96 ns** |    **62,104.5 ns** |     **112 B** |
| **ComputeHash | Streebog-256 | OpenGost**                       | **8KB**          |    **86,050.9 ns** |    **317.50 ns** |    **296.99 ns** |    **86,065.3 ns** |     **464 B** |
| ComputeHash | Streebog-256 | BouncyCastle                   | 8KB          |   113,062.4 ns |    311.40 ns |    291.29 ns |   113,033.4 ns |     200 B |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | Streebog-256 | CryptoHives**                    | **128KB**        |   **993,637.8 ns** |  **5,528.51 ns** |  **4,900.88 ns** |   **990,963.0 ns** |     **112 B** |
| **ComputeHash | Streebog-256 | OpenGost**                       | **128KB**        | **1,353,226.8 ns** |  **4,803.47 ns** |  **4,493.17 ns** | **1,351,968.5 ns** |     **464 B** |
| ComputeHash | Streebog-256 | BouncyCastle                   | 128KB        | 1,746,305.9 ns |  6,697.20 ns |  6,264.56 ns | 1,744,852.7 ns |     200 B |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | Streebog-512 | CryptoHives**                    | **128B**         |     **2,404.6 ns** |      **4.16 ns** |      **3.69 ns** |     **2,403.4 ns** |     **176 B** |
| **ComputeHash | Streebog-512 | OpenGost**                       | **128B**         |     **3,340.8 ns** |      **8.78 ns** |      **8.21 ns** |     **3,340.0 ns** |     **264 B** |
| ComputeHash | Streebog-512 | BouncyCastle                   | 128B         |     4,255.6 ns |     17.75 ns |     16.60 ns |     4,255.7 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | Streebog-512 | CryptoHives**                    | **137B**         |     **2,448.4 ns** |      **4.87 ns** |      **4.55 ns** |     **2,447.6 ns** |     **176 B** |
| **ComputeHash | Streebog-512 | OpenGost**                       | **137B**         |     **3,344.5 ns** |     **10.96 ns** |      **9.72 ns** |     **3,341.3 ns** |     **264 B** |
| ComputeHash | Streebog-512 | BouncyCastle                   | 137B         |     4,266.1 ns |     12.81 ns |     11.99 ns |     4,265.2 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | Streebog-512 | CryptoHives**                    | **1KB**          |     **9,052.1 ns** |     **13.36 ns** |     **12.50 ns** |     **9,048.3 ns** |     **176 B** |
| **ComputeHash | Streebog-512 | OpenGost**                       | **1KB**          |    **14,364.0 ns** |     **44.26 ns** |     **41.40 ns** |    **14,342.6 ns** |     **264 B** |
| ComputeHash | Streebog-512 | BouncyCastle                   | 1KB          |    16,203.2 ns |     52.51 ns |     46.54 ns |    16,200.2 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | Streebog-512 | CryptoHives**                    | **1025B**        |     **8,894.7 ns** |     **23.72 ns** |     **22.18 ns** |     **8,900.3 ns** |     **176 B** |
| **ComputeHash | Streebog-512 | OpenGost**                       | **1025B**        |    **12,523.0 ns** |     **35.58 ns** |     **33.28 ns** |    **12,508.0 ns** |     **264 B** |
| ComputeHash | Streebog-512 | BouncyCastle                   | 1025B        |    16,186.1 ns |     27.88 ns |     23.28 ns |    16,188.8 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | Streebog-512 | CryptoHives**                    | **8KB**          |    **62,777.0 ns** |     **91.32 ns** |     **85.42 ns** |    **62,791.0 ns** |     **176 B** |
| **ComputeHash | Streebog-512 | OpenGost**                       | **8KB**          |    **86,116.7 ns** |    **237.09 ns** |    **210.17 ns** |    **86,087.4 ns** |     **264 B** |
| ComputeHash | Streebog-512 | BouncyCastle                   | 8KB          |   111,251.3 ns |    432.52 ns |    383.42 ns |   111,114.4 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | Streebog-512 | CryptoHives**                    | **128KB**        |   **966,529.9 ns** |  **3,780.55 ns** |  **3,536.33 ns** |   **966,871.2 ns** |     **176 B** |
| **ComputeHash | Streebog-512 | OpenGost**                       | **128KB**        | **1,349,597.9 ns** |  **3,670.27 ns** |  **3,433.17 ns** | **1,348,918.5 ns** |     **264 B** |
| ComputeHash | Streebog-512 | BouncyCastle                   | 128KB        | 1,748,641.4 ns |  5,150.13 ns |  4,817.44 ns | 1,747,016.0 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Scalar  | 128B         |       179.3 ns |      0.68 ns |      0.64 ns |       179.4 ns |     112 B |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Avx512F | 128B         |       206.4 ns |      0.48 ns |      0.45 ns |       206.4 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Scalar  | 137B         |       180.0 ns |      0.45 ns |      0.40 ns |       179.9 ns |     112 B |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Avx512F | 137B         |       208.4 ns |      0.41 ns |      0.39 ns |       208.4 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Scalar  | 1KB          |       866.7 ns |      2.31 ns |      2.16 ns |       866.4 ns |     112 B |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Avx512F | 1KB          |     1,135.2 ns |      2.71 ns |      2.40 ns |     1,134.8 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Scalar  | 1025B        |       867.6 ns |      1.54 ns |      1.28 ns |       867.5 ns |     112 B |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Avx512F | 1025B        |     1,133.3 ns |      2.62 ns |      2.19 ns |     1,133.5 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Scalar  | 8KB          |     5,376.8 ns |     15.53 ns |     14.53 ns |     5,373.8 ns |     112 B |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Avx512F | 8KB          |     7,248.3 ns |     10.04 ns |      8.90 ns |     7,248.5 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Scalar  | 128KB        |    84,501.5 ns |    293.26 ns |    259.97 ns |    84,479.6 ns |     112 B |
| ComputeHash | TurboSHAKE128 | TurboShake128_Managed_Avx512F | 128KB        |   114,564.6 ns |    119.33 ns |    105.78 ns |   114,583.1 ns |     112 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Scalar  | 128B         |       185.0 ns |      0.68 ns |      0.60 ns |       184.9 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Avx512F | 128B         |       213.9 ns |      0.44 ns |      0.39 ns |       213.9 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Scalar  | 137B         |       336.7 ns |      0.81 ns |      0.76 ns |       336.4 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Avx512F | 137B         |       395.1 ns |      0.80 ns |      0.75 ns |       394.9 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Scalar  | 1KB          |       952.1 ns |      3.19 ns |      2.98 ns |       953.4 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Avx512F | 1KB          |     1,265.3 ns |      3.66 ns |      3.06 ns |     1,264.3 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Scalar  | 1025B        |       949.2 ns |      1.78 ns |      1.66 ns |       949.2 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Avx512F | 1025B        |     1,268.0 ns |      2.98 ns |      2.64 ns |     1,268.6 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Scalar  | 8KB          |     6,618.4 ns |     17.30 ns |     16.19 ns |     6,617.8 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Avx512F | 8KB          |     9,031.6 ns |     24.22 ns |     21.47 ns |     9,028.4 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Scalar  | 128KB        |   102,789.0 ns |    283.92 ns |    251.69 ns |   102,738.1 ns |     176 B |
| ComputeHash | TurboSHAKE256 | TurboShake256_Managed_Avx512F | 128KB        |   141,232.0 ns |    374.06 ns |    349.89 ns |   141,196.2 ns |     176 B |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | Whirlpool | CryptoHives**                       | **128B**         |     **1,360.4 ns** |      **3.50 ns** |      **3.28 ns** |     **1,360.3 ns** |     **176 B** |
| **ComputeHash | Whirlpool | BouncyCastle**                      | **128B**         |     **5,024.0 ns** |     **21.00 ns** |     **19.64 ns** |     **5,027.9 ns** |     **232 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | Whirlpool | CryptoHives**                       | **137B**         |     **1,355.1 ns** |      **4.46 ns** |      **4.17 ns** |     **1,356.2 ns** |     **176 B** |
| **ComputeHash | Whirlpool | BouncyCastle**                      | **137B**         |     **5,045.4 ns** |     **13.05 ns** |     **11.57 ns** |     **5,047.0 ns** |     **232 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | Whirlpool | CryptoHives**                       | **1KB**          |     **7,570.8 ns** |     **27.97 ns** |     **26.16 ns** |     **7,562.9 ns** |     **176 B** |
| **ComputeHash | Whirlpool | BouncyCastle**                      | **1KB**          |    **30,806.2 ns** |     **93.68 ns** |     **87.63 ns** |    **30,806.1 ns** |     **232 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | Whirlpool | CryptoHives**                       | **1025B**        |     **7,691.3 ns** |     **30.81 ns** |     **27.32 ns** |     **7,688.2 ns** |     **176 B** |
| **ComputeHash | Whirlpool | BouncyCastle**                      | **1025B**        |    **31,082.4 ns** |     **99.52 ns** |     **93.10 ns** |    **31,073.2 ns** |     **232 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | Whirlpool | CryptoHives**                       | **8KB**          |    **57,996.6 ns** |    **138.57 ns** |    **129.62 ns** |    **57,959.1 ns** |     **176 B** |
| **ComputeHash | Whirlpool | BouncyCastle**                      | **8KB**          |   **236,825.6 ns** |    **550.30 ns** |    **487.83 ns** |   **236,903.3 ns** |     **232 B** |
|                                                             |              |                |              |              |                |           |
| **ComputeHash | Whirlpool | CryptoHives**                       | **128KB**        |   **922,367.0 ns** |  **2,620.74 ns** |  **2,451.45 ns** |   **921,897.9 ns** |     **176 B** |
| **ComputeHash | Whirlpool | BouncyCastle**                      | **128KB**        | **3,760,247.3 ns** | **13,324.35 ns** | **11,811.69 ns** | **3,759,611.1 ns** |     **232 B** |
